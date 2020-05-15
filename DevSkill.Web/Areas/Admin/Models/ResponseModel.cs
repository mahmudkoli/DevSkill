﻿using DevSkill.Web.Areas.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Web.Areas.Admin.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string IconCssClass { get; set; }
        public string StyleCssClass { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(string message, ResponseType type)
        {
            if (type == ResponseType.Success)
            {
                IconCssClass = "fa-check";
                StyleCssClass = "alert-success";
                Title = "Success!";
            }
            else if (type == ResponseType.Failure)
            {
                IconCssClass = "fa-ban";
                StyleCssClass = "alert-danger";
                Title = "Error!";
            }

            Message = message;
        }
    }
}
