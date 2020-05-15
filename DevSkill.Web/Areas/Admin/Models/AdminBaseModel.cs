﻿using Autofac;
using DevSkill.Framework.Extensions;
using DevSkill.Framework.Menus;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Web.Areas.Admin.Models
{
    public class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    {
                        new MenuItem
                        {
                            Title = "Expense",
                            Children = new List<MenuChildItem>
                            {
                                new MenuChildItem () { Controller = "Expenses", Action = "Index", Area="Admin", Title = "View Expense",
                                    Icon = "icon-home4", IsActive = false },
                                new MenuChildItem () { Controller = "Expenses", Action = "Add", Area="Admin", Title = "Add Expense",
                                    Icon = "icon-home4", IsActive = false },
                            }
                        }
                    }
                }
            };
        }
    }
}
