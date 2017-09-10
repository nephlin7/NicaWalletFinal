using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NicaWallet.Helper
{
    public static class CuentaHelper
    {
        public static MvcHtmlString MostrarCuenta(this HtmlHelper htmlhelper, string currencyName, double? amount, string accountTypeName, string lastUpdate, int accountId)
        {
            return MvcHtmlString.Create("<p class='author'>" + currencyName + " " + amount + "</p><p class='inbox-message'>" + accountTypeName + "</p><p class='inbox-date'>" + accountTypeName + "</p><a href='/Cuenta/Edit?id=" + accountId + "' class='btn btn-info outline-btn round' style='float:right;'><i class='icon-note' aria-hidden='true'></i>Edit</a><a AccountId=" + accountId + " class='btn btn-danger outline-btn round btnDelete' style='float:right;margin-right: 10px;'><i class='icon-note' aria-hidden='true'></i>Delete</a>");
        }
    }
}