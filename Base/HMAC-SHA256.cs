using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.Base
{
    //Thanks to Stephan Brumme's Portable C++ Hashing Library.   http://create.stephan-brumme.com/hash-library/
    public class HMAC_SHA256
    {
        const uint BlockSize = 64;
        const uint HashBytes = 32;
        ulong m_numBytes, m_bufferSize;
        uint[] m_hash;
        byte[] m_buffer;

        /// restart
        public HMAC_SHA256()
        {
            m_numBytes = 0;
            m_bufferSize = 0;

            m_hash = new uint[8];
            m_buffer = new byte[BlockSize];

            // according to RFC 1321
            m_hash[0] = 0x6a09e667;
            m_hash[1] = 0xbb67ae85;
            m_hash[2] = 0x3c6ef372;
            m_hash[3] = 0xa54ff53a;
            m_hash[4] = 0x510e527f;
            m_hash[5] = 0x9b05688c;
            m_hash[6] = 0x1f83d9ab;
            m_hash[7] = 0x5be0cd19;
        }

        uint rotate(uint a, int c)
        {
            return (a >> c) | (a << (32 - c));
        }

        uint swap(uint x)
        {

            return (x >> 24) |
                  ((x >> 8) & 0x0000FF00) |
                  ((x << 8) & 0x00FF0000) |
                   (x << 24);
        }

        // mix functions for processBlock()
        uint f1(uint e, uint f, uint g)
        {
            uint term1 = rotate(e, 6) ^ rotate(e, 11) ^ rotate(e, 25);
            uint term2 = (e & f) ^ (~e & g); //(g ^ (e & (f ^ g)))
            return term1 + term2;
        }

        uint f2(uint a, uint b, uint c)
        {
            uint term1 = rotate(a, 2) ^ rotate(a, 13) ^ rotate(a, 22);
            uint term2 = ((a | b) & c) | (a & b); //(a & (b ^ c)) ^ (b & c);
            return term1 + term2;
        }



        /// process 64 bytes
        void processBlock(byte[] data)
        {
            // get last hash
            uint a = m_hash[0];
            uint b = m_hash[1];
            uint c = m_hash[2];
            uint d = m_hash[3];
            uint e = m_hash[4];
            uint f = m_hash[5];
            uint g = m_hash[6];
            uint h = m_hash[7];

            // data represented as 16x 32-bit words
            uint[] input = new uint[16];
            int i;
            for (i = 0; i < 16; i++)
                input[i] = BitConverter.ToUInt32(data, i * 4);

            // convert to big endian
            uint[] words = new uint[64];

            for (i = 0; i < 16; i++)
                words[i] = swap(input[i]);

            uint x, y; // temporaries

            // first round
            x = h + f1(e, f, g) + 0x428a2f98 + words[0]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0x71374491 + words[1]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0xb5c0fbcf + words[2]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0xe9b5dba5 + words[3]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x3956c25b + words[4]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0x59f111f1 + words[5]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x923f82a4 + words[6]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0xab1c5ed5 + words[7]; y = f2(b, c, d); e += x; a = x + y;

            // secound round
            x = h + f1(e, f, g) + 0xd807aa98 + words[8]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0x12835b01 + words[9]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0x243185be + words[10]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0x550c7dc3 + words[11]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x72be5d74 + words[12]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0x80deb1fe + words[13]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x9bdc06a7 + words[14]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0xc19bf174 + words[15]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 24 words
            for (; i < 24; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // third round
            x = h + f1(e, f, g) + 0xe49b69c1 + words[16]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0xefbe4786 + words[17]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0x0fc19dc6 + words[18]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0x240ca1cc + words[19]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x2de92c6f + words[20]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0x4a7484aa + words[21]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x5cb0a9dc + words[22]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0x76f988da + words[23]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 32 words
            for (; i < 32; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // fourth round
            x = h + f1(e, f, g) + 0x983e5152 + words[24]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0xa831c66d + words[25]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0xb00327c8 + words[26]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0xbf597fc7 + words[27]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0xc6e00bf3 + words[28]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0xd5a79147 + words[29]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x06ca6351 + words[30]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0x14292967 + words[31]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 40 words
            for (; i < 40; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // fifth round
            x = h + f1(e, f, g) + 0x27b70a85 + words[32]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0x2e1b2138 + words[33]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0x4d2c6dfc + words[34]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0x53380d13 + words[35]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x650a7354 + words[36]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0x766a0abb + words[37]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x81c2c92e + words[38]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0x92722c85 + words[39]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 48 words
            for (; i < 48; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // sixth round
            x = h + f1(e, f, g) + 0xa2bfe8a1 + words[40]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0xa81a664b + words[41]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0xc24b8b70 + words[42]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0xc76c51a3 + words[43]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0xd192e819 + words[44]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0xd6990624 + words[45]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0xf40e3585 + words[46]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0x106aa070 + words[47]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 56 words
            for (; i < 56; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // seventh round
            x = h + f1(e, f, g) + 0x19a4c116 + words[48]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0x1e376c08 + words[49]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0x2748774c + words[50]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0x34b0bcb5 + words[51]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x391c0cb3 + words[52]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0x4ed8aa4a + words[53]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0x5b9cca4f + words[54]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0x682e6ff3 + words[55]; y = f2(b, c, d); e += x; a = x + y;

            // extend to 64 words
            for (; i < 64; i++)
                words[i] = words[i - 16] +
                           (rotate(words[i - 15], 7) ^ rotate(words[i - 15], 18) ^ (words[i - 15] >> 3)) +
                           words[i - 7] +
                           (rotate(words[i - 2], 17) ^ rotate(words[i - 2], 19) ^ (words[i - 2] >> 10));

            // eigth round
            x = h + f1(e, f, g) + 0x748f82ee + words[56]; y = f2(a, b, c); d += x; h = x + y;
            x = g + f1(d, e, f) + 0x78a5636f + words[57]; y = f2(h, a, b); c += x; g = x + y;
            x = f + f1(c, d, e) + 0x84c87814 + words[58]; y = f2(g, h, a); b += x; f = x + y;
            x = e + f1(b, c, d) + 0x8cc70208 + words[59]; y = f2(f, g, h); a += x; e = x + y;
            x = d + f1(a, b, c) + 0x90befffa + words[60]; y = f2(e, f, g); h += x; d = x + y;
            x = c + f1(h, a, b) + 0xa4506ceb + words[61]; y = f2(d, e, f); g += x; c = x + y;
            x = b + f1(g, h, a) + 0xbef9a3f7 + words[62]; y = f2(c, d, e); f += x; b = x + y;
            x = a + f1(f, g, h) + 0xc67178f2 + words[63]; y = f2(b, c, d); e += x; a = x + y;

            // update hash
            m_hash[0] += a;
            m_hash[1] += b;
            m_hash[2] += c;
            m_hash[3] += d;
            m_hash[4] += e;
            m_hash[5] += f;
            m_hash[6] += g;
            m_hash[7] += h;
        }


        /// add arbitrary number of bytes
        void add(byte[] data, uint numBytes)
        {
            //const uint8_t* current = (const uint8_t*) data;
            uint index = 0;
            if (m_bufferSize > 0)
            {
                while (numBytes > 0 && m_bufferSize < BlockSize)
                {
                    m_buffer[m_bufferSize++] = data[index];
                    index++;
                    numBytes--;
                }
            }

            // full buffer
            if (m_bufferSize == BlockSize)
            {
                processBlock(m_buffer);
                m_numBytes += BlockSize;
                m_bufferSize = 0;
            }

            // no more data ?
            if (numBytes == 0)
                return;

            // process full blocks
            byte[] processData = new byte[BlockSize];
            while (numBytes >= BlockSize)
            {
                Array.Copy(data, (int)index * 64, processData, 0, (int)BlockSize);
                processBlock(processData);
                index++;
                m_numBytes += BlockSize;
                numBytes -= BlockSize;
            }

            // keep remaining bytes in buffer
            while (numBytes > 0)
            {
                m_buffer[m_bufferSize++] = data[data.Length - numBytes];
                index++;
                numBytes--;
            }
        }


        /// process final block, less than 64 bytes
        void processBuffer()
        {
            // the input bytes are considered as bits strings, where the first bit is the most significant bit of the byte

            // - append "1" bit to message
            // - append "0" bits until message length in bit mod 512 is 448
            // - append length as 64 bit integer

            // number of bits
            ulong paddedLength = m_bufferSize * 8;

            // plus one bit set to 1 (always appended)
            paddedLength++;

            // number of bits must be (numBits % 512) = 448
            ulong lower11Bits = paddedLength & 511;
            if (lower11Bits <= 448)
                paddedLength += 448 - lower11Bits;
            else
                paddedLength += 512 + 448 - lower11Bits;
            // convert from bits to bytes
            paddedLength /= 8;

            // only needed if additional data flows over into a second block
            byte[] extra = new byte[BlockSize];

            // append a "1" bit, 128 => binary 10000000
            if (m_bufferSize < BlockSize)
                m_buffer[m_bufferSize] = 128;
            else
                extra[0] = 128;

            ulong i;
            for (i = m_bufferSize + 1; i < BlockSize; i++)
                m_buffer[i] = 0;
            for (; i < paddedLength; i++)
                extra[i - BlockSize] = 0;

            // add message length in bits as 64 bit number
            ulong msgBits = 8 * (m_numBytes + m_bufferSize);
            // find right position

            ulong addLength;
            byte[] temp;
            if (paddedLength < BlockSize)
            {
                temp = m_buffer;
                addLength = paddedLength;
            }
            else
            {
                temp = extra;
                addLength = paddedLength - BlockSize;
            }

            // must be big endian
            temp[addLength++] = (byte)((msgBits >> 56) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 48) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 40) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 32) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 24) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 16) & 0xFF);
            temp[addLength++] = (byte)((msgBits >> 8) & 0xFF);
            temp[addLength] = (byte)(msgBits & 0xFF);

            // process blocks
            processBlock(m_buffer);
            // flowed over into a second block ?
            if (paddedLength > BlockSize)
                processBlock(extra);
        }

        /// return latest hash as bytes
        byte[] getHash(byte[] buffer)
        {
            // save old hash if buffer is partially filled
            int HashValues = 8;
            uint[] oldHash = new uint[HashValues];
            for (int i = 0; i < HashValues; i++)
                oldHash[i] = m_hash[i];

            // process remaining bytes
            processBuffer();

            //unsigned char* current = buffer;
            int index = 0;
            for (int i = 0; i < HashValues; i++)
            {
                buffer[index++] = (byte)((m_hash[i] >> 24) & 0xFF);
                buffer[index++] = (byte)((m_hash[i] >> 16) & 0xFF);
                buffer[index++] = (byte)((m_hash[i] >> 8) & 0xFF);
                buffer[index++] = (byte)(m_hash[i] & 0xFF);

                // restore old hash
                m_hash[i] = oldHash[i];
            }

            return buffer;
        }

        public static string HMAC(byte[] data, byte[] key)
        {
            // initialize key with zeros
            //unsigned char usedKey[HashMethod::BlockSize] = {0};
            uint numDataBytes = (uint)data.Length;
            uint numKeyBytes = (uint)key.Length;
            byte[] usedKey = new byte[BlockSize];

            // adjust length of key: must contain exactly blockSize bytes
            if (numKeyBytes <= BlockSize)
            {
                // copy key
                //memcpy(usedKey, key, numKeyBytes);
                usedKey = key;
                Array.Resize(ref usedKey, (int)BlockSize);
            }
            else
            {
                // shorten key: usedKey = hashed(key)
                HMAC_SHA256 keyHasher = new HMAC_SHA256();
                keyHasher.add(key, numKeyBytes);
                keyHasher.getHash(usedKey);
            }

            // create initial XOR padding
            for (int i = 0; i < BlockSize; i++)
                usedKey[i] ^= 0x36;

            // inside = hash((usedKey ^ 0x36) + data)
            byte[] inside = new byte[HashBytes];
            HMAC_SHA256 insideHasher = new HMAC_SHA256();
            insideHasher.add(usedKey, BlockSize);
            insideHasher.add(data, numDataBytes);
            inside = insideHasher.getHash(inside);

            // undo usedKey's previous 0x36 XORing and apply a XOR by 0x5C
            for (int i = 0; i < BlockSize; i++)
                usedKey[i] ^= 0x5C ^ 0x36;

            // hash((usedKey ^ 0x5C) + hash((usedKey ^ 0x36) + data))
            HMAC_SHA256 finalHasher = new HMAC_SHA256();
            finalHasher.add(usedKey, BlockSize);
            finalHasher.add(inside, HashBytes);

            byte[] buffer = new byte[32];

            return Convert.ToBase64String(finalHasher.getHash(buffer));
        }
    }
}
