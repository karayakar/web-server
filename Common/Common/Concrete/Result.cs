﻿using System;

using VueServer.Common.Enums;
using VueServer.Common.Interface;

namespace VueServer.Common.Concrete
{
    public class Result<T> : IResult<T>, IResult
    {
        public T Obj { get; set; }

        public StatusCode Code { get; set; }

        Object IResult.Obj
        {
            get
            {
                return (T) Obj;
            }
            set
            {
                if (!(value is T))
                {
                    throw new ArgumentException($"The type of {value.GetType().Name} cannot be assigned to type of {typeof(T).Name}");
                }

                Obj = (T)value;
            }
        }

        public Result()
        {
            Obj = default(T);
            Code =  StatusCode.OK;
        }

        public Result(T obj, StatusCode code = StatusCode.OK)
        {
            Obj = obj;
            Code = code;
        }
    }
}
