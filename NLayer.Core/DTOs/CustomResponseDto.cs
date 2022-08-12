﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{

    public class CustomNoContentResponseDto<T>
    {

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success(int StatusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int StatusCode)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, String error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }

    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success (int StatusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = data};
        }

        public static CustomResponseDto<T> Success(int StatusCode)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode};
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode , Errors = errors};
        }

        public static CustomResponseDto<T> Fail(int statusCode, String error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
