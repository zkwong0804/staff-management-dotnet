using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StaffManagement.Model;

namespace StaffManagement.Web.Kernel
{
    public static class HtmlExtension
    {
        public static IHtmlContent ExtendedDetailTextInput(this IHtmlHelper helper, string fieldName, string fieldValue, bool isViewMode)
        {
            var divContainer = new TagBuilder("div");
            var label = new TagBuilder("label");
            var fieldDivContainer = new TagBuilder("div");

            divContainer.AddCssClass("form-group row");
            label.MergeAttribute("for", fieldName);
            label.AddCssClass("col-sm-2 col-form-label");
            label.InnerHtml.AppendHtml(fieldName);
            fieldDivContainer.AddCssClass("col-sm-10");

            var textBox = helper.TextBox(fieldName, fieldValue, GetFormInputAttributes(fieldName, isViewMode, !fieldName.Equals("Id")));
            var validationMessage = helper.ValidationMessage(fieldName, new { @class="text-danger"});

            fieldDivContainer.InnerHtml.AppendHtml(textBox);
            fieldDivContainer.InnerHtml.AppendHtml(validationMessage);
            divContainer.InnerHtml.AppendHtml(label);
            divContainer.InnerHtml.AppendHtml(fieldDivContainer);

            return divContainer;

        }

        private static Dictionary<string, object> GetFormInputAttributes(string id, bool isViewMode, bool isEditable = true)
        {
            var attributes = new Dictionary<string, object>();
            attributes.Add("class", isViewMode ? "form-control-plaintext" : "form-control");
            attributes.Add("id", id);
            if (isViewMode || !isEditable)
            {
                attributes.Add("readonly", string.Empty);
            }

            return attributes;
        }
    }
}
