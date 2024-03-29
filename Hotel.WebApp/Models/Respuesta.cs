﻿namespace Hotel.WebApp.Models
{
    public class Respuesta
    {
        public Respuesta()
        {
        }

        public Respuesta(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
