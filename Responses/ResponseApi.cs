using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Responses
{
    public class ResponseApi<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public static ResponseApi<T> Success(T data,int statuscode)
        {
            return new ResponseApi<T> { Data=data,StatusCode=statuscode,IsSuccess=true };

        }
        public static ResponseApi<T>Success(int statuscode)
        {
            return new ResponseApi<T> { IsSuccess=true, StatusCode=statuscode };
        }
        public static ResponseApi<T>Errror(int statuscode, List<string> errors)
        {
            return new ResponseApi<T> { StatusCode=statuscode, Errors=errors, IsSuccess=false };
        }
        public static ResponseApi<T>Error(int statuscode,string error)
        {
            return new ResponseApi<T> { IsSuccess=false, StatusCode=statuscode, Errors=new List<string> { error } };
        }
    }
}
