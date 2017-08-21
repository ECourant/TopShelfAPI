using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Document"/>s.
    /// </summary>
    public sealed class DocumentsPipeline : Base.TPipeline
    {
        internal DocumentsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "documents";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public Document this [int documentID] => this.GetDocument(documentID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        public Document this [string documentNumber] => this.GetDocument(documentNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Document[] GetDocuments() => this.GetPlural<Document>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public Document[] GetDocuments(params Basics.IFilter[] filters) => this.GetPlural<Document>(filters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Document[] GetDocuments(int pageNum, int pageSize) => this.GetPlural<Document>(pageNum, pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public Document GetDocument(int documentID) => this.GetSingular<Document>(documentID, "DocumentID");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        public Document GetDocument(string documentNumber) => this.GetSingular<Document>(documentNumber, "DocNumber");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public Document[] CreateDocuments(params Document[] documents) => this.CreatePlural<Document>(documents);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public Document[] UpdateDocuments(params Document[] documents) => this.UpdatePlural<Document>(documents);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public bool DeleteDocuments(params Document[] documents) => this.DeletePlural<Document>(documents);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentIDs"></param>
        /// <returns></returns>
        public bool DeleteDocuments(params int[] documentIDs) => this.DeletePlural<Document>(documentIDs.Select(DocumentID => new Document()
        {
            DocumentID = DocumentID
        }).ToArray());
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentID"></param>
        /// <param name="documentDetailIDs"></param>
        /// <returns></returns>
        public bool DeleteDocumentDetails(int documentID, params int[] documentDetailIDs) => this.DeletePlural<Document>(new Document()
        {
            DocumentID = documentID,
            DocumentDetails = documentDetailIDs.Select(DocumentDetailID => new DocumentDetail()
            {
                DocumentDetailID = DocumentDetailID
            }).ToArray()
        });

#if LANG_VERSION_7
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public bool DeleteDocumentDetails(params (int documentID, int[] documentDetailIDs)[] documents) => this.DeletePlural<Document>(documents.Select(Document => new Document() 
        { 
            DocumentID = Document.documentID, 
            DocumentDetails = Document.documentDetailIDs.Select(DocumentDetailID => new DocumentDetail() 
            { 
                DocumentDetailID = DocumentDetailID 
            }).ToArray() 
        }).ToArray());
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        public bool DeleteDocumentDetails(params Tuple<int, int[]>[] documents) => this.DeletePlural<Document>(documents.Select(Document => new Document()
        {
            DocumentID = Document.Item1,
            DocumentDetails = Document.Item2.Select(DocumentDetailID => new DocumentDetail()
            {
                DocumentDetailID = DocumentDetailID
            }).ToArray()
        }).ToArray());
#endif
    }
}
