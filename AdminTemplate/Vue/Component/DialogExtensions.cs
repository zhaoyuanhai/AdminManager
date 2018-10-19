using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace AdminTemplate.Vue.Component
{
    public static class DialogExtensions
    {
        private static MvcVueDialog MvcVueDialog;
        private static MvcVueFormDialog MvcVueFormDialog;

        /// <summary>
        /// Dialog 对话框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="visible">是否显示 Dialog，支持 .sync 修饰符</param>
        /// <param name="title">Dialog 的标题，也可通过具名 slot （见下表）传入</param>
        /// <param name="width">Dialog 的宽度</param>
        /// <param name="fullscreen">是否为全屏 Dialog</param>
        /// <param name="top">Dialog CSS 中的 margin-top 值</param>
        /// <param name="modal">是否需要遮罩层</param>
        /// <param name="modalAppendToBody">遮罩层是否插入至 body 元素上，若为 false，则遮罩层会插入至 Dialog 的父元素上</param>
        /// <param name="appendToBody">Dialog 自身是否插入至 body 元素上。嵌套的 Dialog 必须指定该属性并赋值为 true</param>
        /// <param name="lockScroll">是否在 Dialog 出现时将 body 滚动锁定</param>
        /// <param name="customClass">Dialog 的自定义类名</param>
        /// <param name="closeOnClickModal">是否可以通过点击 modal 关闭 Dialog</param>
        /// <param name="closeOnPressEscape">是否可以通过按下 ESC 关闭 Dialog</param>
        /// <param name="showClose">是否显示关闭按钮</param>
        /// <param name="beforeClose">关闭前的回调，会暂停 Dialog 的关闭</param>
        /// <param name="center">是否对头部和底部采用居中布局</param>
        /// <returns></returns>
        public static MvcVueDialog BeginDialog(this VueElementUIHelper helper, MvcVueDialog.Options options = null)
        {
            MvcVueDialog = new MvcVueDialog(helper.Html.ViewContext, options);
            return MvcVueDialog;
        }

        public static void EndDialog(this VueElementUIHelper helper)
        {
            MvcVueDialog.Dispose();
        }

        public static MvcVueFormDialog BeginFormDialog(this VueElementUIHelper helper, MvcVueDialog.Options options = null)
        {
            MvcVueFormDialog = new MvcVueFormDialog(helper.Html.ViewContext, options);
            return MvcVueFormDialog;
        }

        public static void EndFormDialog(this VueElementUIHelper helper)
        {
            MvcVueFormDialog.Dispose();
        }
    }

    public class MvcVueDialog : IDisposable
    {
        private ViewContext viewContext;

        public MvcVueDialog(ViewContext viewContext, Options options)
        {
            this.viewContext = viewContext;
            var _ref = (options.@ref == null ? string.Empty : $"ref=\"{options.@ref}\"");
            this.viewContext.Writer.Write($"<el-dialog {_ref}{options.Attributes}>\r\n");
        }

        public void Dispose()
        {
            this.viewContext.Writer.Write("</el-dialog>\r\n");
        }

        public class Options : OptionsBase
        {
            /// <summary>
            /// 是否显示 Dialog，支持 .sync 修饰符
            /// </summary>
            public string visible { get; set; }

            /// <summary>
            /// Dialog 的标题，也可通过具名 slot （见下表）传入
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// Dialog 的宽度
            /// </summary>
            public string width { get; set; }

            /// <summary>
            /// 是否为全屏 Dialog
            /// </summary>
            public string fullscreen { get; set; }

            /// <summary>
            /// Dialog CSS 中的 margin-top 值
            /// </summary>
            public string top { get; set; }

            /// <summary>
            /// 是否需要遮罩层
            /// </summary>
            public string modal { get; set; }

            /// <summary>
            /// 遮罩层是否插入至 body 元素上，若为 false，则遮罩层会插入至 Dialog 的父元素上
            /// </summary>
            public string modalAppendToBody { get; set; }

            /// <summary>
            /// Dialog 自身是否插入至 body 元素上。嵌套的 Dialog 必须指定该属性并赋值为 true
            /// </summary>
            public string appendToBody { get; set; }

            /// <summary>
            /// 是否在 Dialog 出现时将 body 滚动锁定
            /// </summary>
            public string lockScroll { get; set; }

            /// <summary>
            /// Dialog 的自定义类名
            /// </summary>
            public string customClass { get; set; }

            /// <summary>
            /// 是否可以通过点击 modal 关闭 Dialog
            /// </summary>
            public string closeOnClickModal { get; set; }

            /// <summary>
            /// 是否可以通过按下 ESC 关闭 Dialog
            /// </summary>
            public string closeOnPressEscape { get; set; }

            /// <summary>
            /// 是否显示关闭按钮
            /// </summary>
            public string showClose { get; set; }

            /// <summary>
            /// 关闭前的回调，会暂停 Dialog 的关闭
            /// </summary>
            public string beforeClose { get; set; }

            /// <summary>
            /// 是否对头部和底部采用居中布局
            /// </summary>
            public string center { get; set; }
        }
    }

    public class MvcVueFormDialog : IDisposable
    {
        private ViewContext viewContext;

        public MvcVueFormDialog(ViewContext viewContext, MvcVueDialog.Options options)
        {
            if (options == null)
            {
                options = new MvcVueDialog.Options()
                {
                    title = ":title",
                    visible = ":dialogVisible",
                    beforeClose = ":handleClose",
                    @ref = ""
                };
            }
            else
            {
                options.title = options.title ?? "";
                options.visible = options.visible ?? "";
                options.beforeClose = options.beforeClose ?? "";
                options.@ref = options.@ref ?? "";
            }

            this.viewContext = viewContext;

            this.viewContext.Writer.Write(
                $"<el-dialog{options?.Attributes}>\r\n" +
                "   <div>\r\n"
            );
        }

        public void Dispose()
        {
            viewContext.Writer.Write(
                "   </div>\r\n" +
                "   <span slot=\"footer\" class=\"dialog-footer\">\r\n" +
                "       <el-button @click=\"handleCancel\">取 消</el-button>\r\n" +
                "       <el-button type=\"primary\" @@click=\"submit('modelForm')\">确 定</el-button>\r\n" +
                "   </span>\r\n"
            );
            viewContext.Writer.Write("</el-dialog>");
        }
    }
}