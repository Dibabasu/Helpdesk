using System;

namespace Helpdesk.WebApi.ResponseModel
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Result { get; set; }
        public DateTime? LastSyncDateTime { get; set; }


        /// <summary>
        /// ResponseWrapper is responsible to send response to consumer.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="result"></param>
        /// <param name="errorMessage"></param>
        /// <param name="lastSyncDateTime"></param>
        public ResponseModel(int statusCode, object result = null, string errorMessage = "")
        {
            try
            {
                this.StatusCode = statusCode;
                this.ErrorMessage = errorMessage;


                if (result != null)
                    Result = result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
