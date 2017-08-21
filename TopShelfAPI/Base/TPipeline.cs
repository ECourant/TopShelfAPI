using System;
using System.Collections.Generic;
using System.Linq;
using TopShelfAPI.Helpers;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// This is used as a template for the basic functions for communicating with TopShelf and translating the API's response into an object.
    /// </summary>
    public abstract class TPipeline
    {
        private Network.TSRequestDelegate SendRequestDelegate;

        internal TPipeline(Network.TSRequestDelegate sendRequestDelegate) => this.SendRequestDelegate = sendRequestDelegate;

        protected internal virtual int MaxPageSize => TSDefaults.MaxPageSize;

        /// <summary>
        /// Gets the default endpoint for making API calls. "http://api.scoutsft.com/{DefaultTarget}"
        /// </summary>
        protected abstract string DefaultTarget { get; }

        internal Network.TSResponse SendRequest(Basics.IRequest request) => this.SendRequestDelegate(request) as Network.TSResponse;

        protected internal Filtering.TSFilter GetPageNumberFilter(int page) => new Filtering.TSFilter("page_num", page.ToString());

        protected internal Filtering.TSFilter GetPageSize() => new Filtering.TSFilter("page_size", this.MaxPageSize.ToString());

        protected internal Filtering.TSFilter GetPageSize(int pageSize) => new Filtering.TSFilter("page_size", pageSize.ToString());

        protected internal T[] GetPlural<T>(params Basics.IFilter[] filters) where T : Basics.ITopShelfObject
        {
            List<T> Returned = new List<T>();
            int Page = 1;
            while (true)
            {
                Network.TSResponse Response = null;
                var FiltersGenerated = filters == null ? new[] { this.GetPageNumberFilter(Page), this.GetPageSize() } : new[] { this.GetPageNumberFilter(Page), this.GetPageSize() }.Concat(filters.Where(Filter => Filter.Name != "page_num" && Filter.Name != "page_size")).ToArray();
                Response = this.SendRequest(
                    new Network.TSRequest()
                    {
                        Body = string.Empty,
                        Filters = FiltersGenerated,
                        Target = this.DefaultTarget,
                        Type = Enums.RequestType.GET
                    });
                T[] Retreived = this.GetResult<T>(Response);
                if (Retreived.Count() > 0)
                    foreach (var Item in Retreived)
                        Returned.Add(Item);
                else
                    break;
                Page++;
            }

            return Returned.ToArray();
        }

        protected internal T[] GetPlural<T>(int pageNum, int pageSize, params Basics.IFilter[] filters) where T : Basics.ITopShelfObject
        {
            if (pageNum <= 0)
                throw new ArgumentOutOfRangeException("pageNum", "Error, the page number cannot be less than 1");
            if (pageSize <= 0 || pageSize > this.MaxPageSize)
                throw new ArgumentOutOfRangeException("pageSize", $"Error, the page size cannot be less than 1 and cannot be greater than {this.MaxPageSize}");
            Network.TSResponse Response = null;
            var FiltersGenerated = filters == null ? new[] { this.GetPageNumberFilter(pageNum), this.GetPageSize(pageSize) } : new[] { this.GetPageNumberFilter(pageNum), this.GetPageSize(pageSize) }.Concat(filters.Where(Filter => Filter.Name != "page_num" && Filter.Name != "page_size")).ToArray();
            Response = this.SendRequest(
                new Network.TSRequest()
                {
                    Body = string.Empty,
                    Filters = FiltersGenerated,
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.GET
                });
            return this.GetResult<T>(Response);
        }

        protected internal T GetSingular<T>(int id, string filterKey, params Basics.IFilter[] filters) where T : Basics.ITopShelfObject
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id", "Error, the id cannot be less than 1");
            Network.TSResponse Response = null;
            var FiltersGenerated = filters == null ? new[] { new Filtering.TSFilter(filterKey, id.ToString()) } : new[] { new Filtering.TSFilter(filterKey, id.ToString()) }.Concat(filters.Where(Filter => Filter.Name != "page_num" && Filter.Name != "page_size")).ToArray();
            Response = this.SendRequest(
                new Network.TSRequest()
                {
                    Body = string.Empty,
                    Filters = FiltersGenerated,
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.GET
                });
            return this.GetResult<T>(Response).FirstOrDefault();
        }

        protected internal T GetSingular<T>(string name, string filterKey, params Basics.IFilter[] filters) where T : Basics.ITopShelfObject
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException("name", "Error, the name cannot be null or white space!");
            Network.TSResponse Response = null;
            var FiltersGenerated = filters == null ? new[] { new Filtering.TSFilter(filterKey, name.ToString()) } : new[] { new Filtering.TSFilter(filterKey, name.ToString()) }.Concat(filters.Where(Filter => Filter.Name != "page_num" && Filter.Name != "page_size")).ToArray();
            Response = this.SendRequest(
                new Network.TSRequest()
                {
                    Body = string.Empty,
                    Filters = FiltersGenerated,
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.GET
                });
            return this.GetResult<T>(Response).FirstOrDefault();
        }

        protected internal T[] CreatePlural<T>(params T[] items) where T : Base.TEnumerableItem, Basics.ITopShelfObject
        {
            if ((items ?? new T[] { }).Count() == 0)
                throw new ArgumentNullException("items", "Error, you cannot create 0 items!");
            Network.TSResponse Response = null;
            Response = this.SendRequest(
                new Network.TSAdvancedRequest<T>(items)
                {
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.POST
                });
            return this.GetResult<T>(Response);
        }

        protected internal T[] UpdatePlural<T>(params T[] items) where T : Base.TEnumerableItem, Basics.ITopShelfObject
        {
            if ((items ?? new T[] { }).Count() == 0)
                throw new ArgumentNullException("items", "Error, you cannot update 0 items!");
            IEnumerable<T> Temp = items.Where(Item => Item.ItemID == null && Item.ItemID <= 0 && string.IsNullOrWhiteSpace(Item.ItemName)); // Check to see if there are any items provided that do not have either of the required identifiers.
            if (Temp.Count() > 0)
                throw new ArgumentException("items", $"Error, {Temp.Count()} items(s) provided have no ID or Name and cannot be updated!");
            Network.TSResponse Response = null;
            Response = this.SendRequest(
                new Network.TSAdvancedRequest<T>(items)
                {
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.PUT
                });
            return this.GetResult<T>(Response);
        }

        protected internal bool UpdatePluralResponseless<T>(params T[] items) where T : Base.TEnumerableItem, Basics.ITopShelfObject
        {
            if ((items ?? new T[] { }).Count() == 0)
                throw new ArgumentNullException("items", "Error, you cannot update 0 items!");
            IEnumerable<T> Temp = items.Where(Item => Item.ItemID == null && Item.ItemID <= 0 && string.IsNullOrWhiteSpace(Item.ItemName)); // Check to see if there are any items provided that do not have either of the required identifiers.
            if (Temp.Count() > 0)
                throw new ArgumentException("items", $"Error, {Temp.Count()} items(s) provided have no ID or Name and cannot be updated!");
            Network.TSResponse Response = null;
            Response = this.SendRequest(
                new Network.TSAdvancedRequest<T>(items)
                {
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.PUT
                });
            return (Response ?? new Network.TSResponse()).Code == TSDefaults.SuccessfulDeleteCode;
        }

        protected internal bool DeletePlural<T>(params T[] items) where T : Base.TEnumerableItem, Basics.ITopShelfObject
        {
            if ((items ?? new T[] { }).Count() == 0)
                throw new ArgumentNullException("items", "Error, you cannot delete 0 clients!");
            if (items.Select(Item => Item.ItemID == null || Item.ItemID <= 0).Contains(true))
                throw new ArgumentOutOfRangeException("items", $"Error, items cannot be deleted if their ID is null or less than 1!");
            Network.TSResponse Response = null;
            Response = this.SendRequest(
                new Network.TSAdvancedRequest<T>(items)
                {
                    Target = this.DefaultTarget,
                    Type = Enums.RequestType.DELETE
                });
            return (Response ?? new Network.TSResponse()).Code == TSDefaults.SuccessfulDeleteCode;
        }

        private bool _IsInvalidResponseBody(string responseBody) => (string.IsNullOrWhiteSpace(responseBody) || responseBody == "[]");

        private T[] GetResult<T>(Basics.IResponse response) where T : Basics.ITopShelfObject
        {
            T[] Items = null;
            Network.TopShelfException TSException = null;
            if (response == null)
                return new T[] { };
            else
            {
                if (response.Code == 401)
                    throw new UnauthorizedAccessException("Error, Access is denied due to invalid credentials.");
                if (this._IsInvalidResponseBody(response.Body))
                    return new T[] { };
                else
                {
                    Extensions.Try(() => TSException = Newtonsoft.Json.JsonConvert.DeserializeObject<Network.TopShelfException>(response.Body));
                    if (TSException != null && !string.IsNullOrWhiteSpace(TSException.Message))
                        if (string.IsNullOrWhiteSpace(TSException.MessageDetail))
                            throw new AggregateException($"{TSException.Message}");
                        else
                            throw new AggregateException($"{TSException.Message} {TSException.MessageDetail}");
                    Items = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonTemplates.JsonResponse<T>>(response.Body).Items;
                    return Items ?? new T[] { };
                }
            }
        }
    }
}
