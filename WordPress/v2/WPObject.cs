using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.Base;

namespace WooCommerce.NET.WordPress.v2
{
    public class WPObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        where T1 : Posts where T2 : PostRevisions where T3 : Categories where T4 : Tags where T5 : Pages where T6 : Comments
        where T7 : Taxonomies where T8 : Media where T9 : Users where T10 : PostTypes where T11 : PostStatuses where T12 : Settings
    {
       
        protected RestAPI API { get; set; }
        public WPObject(RestAPI api)
        {
            API = api;

            Post = new WPPostItem(api);
            Categories = new WCItem<T3>(api);
            Tags = new WCItem<T4>(api);
            Pages = new WCItem<T5>(api);
            Comments = new WCItem<T6>(api);
            Taxonomies = new WCItem<T7>(api);
            Media = new WPMediaItem(api);
            Users = new WCItem<T9>(api);
            PostTypes = new WCItem<T10>(api);
            PostStatuses = new WCItem<T11>(api);
            Settings = new WPSettingItem(api);
        }

        public WPPostItem Post { get; protected set; }

        public WCItem<T3> Categories { get; protected set; }

        public WCItem<T4> Tags { get; protected set; }

        public WCItem<T5> Pages { get; protected set; }

        public WCItem<T6> Comments { get; protected set; }

        public WCItem<T7> Taxonomies { get; protected set; }

        public WPMediaItem Media { get; protected set; }

        public WCItem<T9> Users { get; protected set; }

        public WCItem<T10> PostTypes { get; protected set; }

        public WCItem<T11> PostStatuses { get; protected set; }

        public WPSettingItem Settings { get; protected set; }

        public class WPPostItem : WCItem<T1>
        {
            public WPPostItem(RestAPI api) : base(api)
            {
                API = api;

                Revisions = new WCSubItem<T2>(api, APIEndpoint);
            }

            public WCSubItem<T2> Revisions { get; set; }
        }

        public class WPMediaItem : WCItem<T8>
        {
            public WPMediaItem(RestAPI api) : base(api)
            {
                API = api;
            }

            public async Task<T8> Add(string fileName, string filePath)
            {
                Dictionary<string, string> ps = new Dictionary<string, string>();
                ps.Add("name", fileName);
                ps.Add("path", filePath);

                return API.DeserializeJSon<T8>(await API.PostRestful(APIEndpoint, "fileupload", ps).ConfigureAwait(false));
            }
        }

        public class WPSettingItem : WCItem<T12>
        {
            public WPSettingItem(RestAPI api) : base(api)
            {
                API = api;
            }

            public async Task<T12> Get(Dictionary<string, string> parms = null)
            {
                return API.DeserializeJSon<T12>(await API.GetRestful(APIEndpoint, parms).ConfigureAwait(false));
            }
        }
    }

    public class WPObject: WPObject<Posts, PostRevisions, Categories, Tags, Pages, Comments, Taxonomies, Media, Users, PostTypes, PostStatuses, Settings>
    {
        public WPObject(RestAPI api) : base(api)
        {
        }
    }

    public class Plugins
    {
        public static string Endpoint { get { return "plugins"; } }
    }
}

namespace WooCommerce.NET.WordPress.v2.Extension
{
    public static class WPExtension
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => tcs.TrySetResult(true)))
                if (task != await Task.WhenAny(task, tcs.Task))
                    throw new OperationCanceledException(cancellationToken);
            return await task;
        }

        public static async Task WithCancellation(this Task task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => tcs.TrySetResult(true)))
                if (task != await Task.WhenAny(task, tcs.Task))
                    throw new OperationCanceledException(cancellationToken);
            await task;
        }

    }
}