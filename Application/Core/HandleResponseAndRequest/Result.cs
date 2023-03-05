﻿namespace Application.Core.HandleResponseAndRequest
{
    public class Result<T>
    {

        public bool IsSuccess { get; set; }
        public T Value{ get; set; }
        public string Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> { Value = value ,IsSuccess=true};
        public static Result<T> Failure(string error) => new Result<T> { Error = error ,IsSuccess=false};
    }
}
