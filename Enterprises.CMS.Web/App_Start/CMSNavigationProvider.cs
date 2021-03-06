﻿using Abp.Application.Navigation;
using Abp.Localization;

namespace Enterprises.CMS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class CMSNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "用户管理",
                        new LocalizableString("UserManage", CMSConsts.LocalizationSourceName),
                        url: "admin/users",
                        icon: "icon-user"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "角色管理",
                        new LocalizableString("RoleManage", CMSConsts.LocalizationSourceName),
                        url: "admin/role",
                        icon: "icon-inbox"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "新闻类型管理",
                        new LocalizableString("NewsTypeManage", CMSConsts.LocalizationSourceName),
                        url: "admin/NewsType",
                        icon: "icon-th-large"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "新闻公告管理",
                        new LocalizableString("NewsManage", CMSConsts.LocalizationSourceName),
                        url: "admin/News",
                        icon: "icon-book"
                    )
                ); ;
        }
    }
}
