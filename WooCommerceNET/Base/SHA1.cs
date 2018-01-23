using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCommerceNET.Base
{
    //Thanks to Michael Leonhard's SHA1 project. http://www.tamale.net/sha1/
    public class SHA1
    {
        uint H0, H1, H2, H3, H4, unprocessedBytes, size;
        byte[] bytes = new byte[64];

        public SHA1(string message)
        {
            // initialize
            H0 = 0x67452301;
            H1 = 0xefcdab89;
            H2 = 0x98badcfe;
            H3 = 0x10325476;
            H4 = 0xc3d2e1f0;
            unprocessedBytes = 0;
            size = 0;

            byte[] data = Encoding.UTF8.GetBytes(message);
            addBytes(data, (uint)data.Length);
        }

        // circular left bit rotation.  MSB wraps around to LSB
        uint lrot(uint x, int bits)
        {
            return (x << bits) | (x >> (32 - bits));
        }

        // Save a 32-bit unsigned integer to memory, in big-endian order
        void storeBigEndianUint32(byte[] data, uint pos, uint num)
        {
            data[pos + 0] = (byte)(num >> 24);
            data[pos + 1] = (byte)(num >> 16);
            data[pos + 2] = (byte)(num >> 8);
            data[pos + 3] = (byte)num;
        }

        // process ***********************************************************
        void process()
        {
            uint a, b, c, d, e, K, f, t;
            uint[] W = new uint[80];
            // starting values
            a = H0;
            b = H1;
            c = H2;
            d = H3;
            e = H4;
            // copy and expand the message block
            for (t = 0; t < 16; t++)
                W[t] = (uint)((bytes[t * 4] << 24) + (bytes[t * 4 + 1] << 16) + (bytes[t * 4 + 2] << 8) + bytes[t * 4 + 3]);
            for (; t < 80; t++)
                W[t] = lrot(W[t - 3] ^ W[t - 8] ^ W[t - 14] ^ W[t - 16], 1);

            /* main loop */
            uint temp;
            for (t = 0; t < 80; t++)
            {
                if (t < 20)
                {
                    K = 0x5a827999;
                    f = (b & c) | ((b ^ 0xFFFFFFFF) & d);//TODO: try using ~
                }
                else if (t < 40)
                {
                    K = 0x6ed9eba1;
                    f = b ^ c ^ d;
                }
                else if (t < 60)
                {
                    K = 0x8f1bbcdc;
                    f = (b & c) | (b & d) | (c & d);
                }
                else
                {
                    K = 0xca62c1d6;
                    f = b ^ c ^ d;
                }
                temp = lrot(a, 5) + f + e + W[t] + K;
                e = d;
                d = c;
                c = lrot(b, 30);
                b = a;
                a = temp;
            }
            /* add variables */
            H0 += a;
            H1 += b;
            H2 += c;
            H3 += d;
            H4 += e;

            /* all bytes have been processed */
            unprocessedBytes = 0;
        }

        // addBytes **********************************************************
        void addBytes(byte[] data, uint num)
        {
            // add these bytes to the running total
            size += num;
            // repeat until all data is processed
            while (num > 0)
            {
                // number of bytes required to complete block
                uint needed = 64 - unprocessedBytes;
                //assert( needed > 0 );
                // number of bytes to copy (use smaller of two)
                uint toCopy = (num < needed) ? num : needed;
                // Copy the bytes
                //memcpy( bytes + unprocessedBytes, data, toCopy );
                for (int i = 0; i < toCopy; i++)
                    bytes[unprocessedBytes + i] = data[i];

                // Bytes have been copied
                num -= toCopy;
                //data += toCopy;
                unprocessedBytes += toCopy;

                // there is a full block
                if (unprocessedBytes == 64) process();
            }
        }

        // digest ************************************************************
        public string GetHash()
        {
            // save the message size
            uint totalBitsL = size << 3;
            uint totalBitsH = size >> 29;
            // add 0x80 to the message
            addBytes(new byte[] { 0x80 }, 1);

            byte[] footer = {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // block has no room for 8-byte filesize, so finish it
            if (unprocessedBytes > 56)
                addBytes(footer, 64 - unprocessedBytes);
            //assert( unprocessedBytes <= 56 );
            // how many zeros do we need
            uint neededZeros = 56 - unprocessedBytes;
            // store file size (in bits) in big-endian format
            storeBigEndianUint32(footer, neededZeros, totalBitsH);
            storeBigEndianUint32(footer, neededZeros + 4, totalBitsL);
            // finish the final block
            addBytes(footer, neededZeros + 8);
            // allocate memory for the digest bytes
            byte[] digest = new byte[20];
            // copy the digest bytes
            storeBigEndianUint32(digest, 0, H0);
            storeBigEndianUint32(digest, 4, H1);
            storeBigEndianUint32(digest, 8, H2);
            storeBigEndianUint32(digest, 12, H3);
            storeBigEndianUint32(digest, 16, H4);
            // return the digest

            string sbinary = "";

            for (int i = 0; i < digest.Length; i++)
            {
                sbinary += digest[i].ToString("X2"); // hex format
            }
            return sbinary.ToLower();
        }
    }
}
