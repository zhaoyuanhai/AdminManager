using System;
using System.Collections.Generic;

namespace AdminTemplate.MetadataProviders
{
    public class ModelMetadata
    {
        //
        // 摘要:
        //     获取或设置一个值，该值指示模型是否为只读。
        //
        // 返回结果:
        //     如果该模型为只读，则为 true；否则为 false。
        public virtual bool IsReadOnly { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示模型是否为必需的。
        //
        // 返回结果:
        //     如果该模型是必需的，则为 true；否则为 false。
        public virtual bool IsRequired { get; set; }

        //
        // 摘要:
        //     获取模型的值。
        //
        // 返回结果:
        //     模型的值。有关 System.Web.Mvc.ModelMetadata 的更多信息，请参见 Brad Wilson 的博客上的文章 ASP.NET MVC
        //     2 Templates, Part 2: ModelMetadata
        public object Model { get; set; }

        //
        // 摘要:
        //     获取模型的类型。
        //
        // 返回结果:
        //     模型的类型。
        public string ModelType { get; }

        //
        // 摘要:
        //     获取或设置要为 null 值显示的字符串。
        //
        // 返回结果:
        //     要为 null 值显示的字符串。
        public virtual string NullDisplayText { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值表示当前元数据的顺序。
        //
        // 返回结果:
        //     当前元数据的顺序值。
        public virtual int Order { get; set; }

        //
        // 摘要:
        //     获取模型元数据对象的集合，这些对象描述模型的属性。
        //
        // 返回结果:
        //     用于描述模型属性的模型元数据对象的集合。
        public virtual List<ModelMetadata> Properties { get; set; } = new List<ModelMetadata>();

        //
        // 摘要:
        //     获取属性名称。
        //
        // 返回结果:
        //     属性名称。
        public string PropertyName { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示是否启用请求验证。
        //
        // 返回结果:
        //     如果启用了请求验证，则为 true；否则为 false。
        public virtual bool RequestValidationEnabled { get; set; }

        //
        // 摘要:
        //     获取或设置短显示名称。
        //
        // 返回结果:
        //     短显示名称。
        public virtual string ShortDisplayName { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示属性是否应显示在只读视图（如列表和详细信息视图）中。
        //
        // 返回结果:
        //     如果应在只读视图中显示模型，则为 true；否则为 false。
        public virtual bool ShowForDisplay { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示是否应在可编辑视图中显示模型。
        //
        // 返回结果:
        //     如果应在可编辑视图中显示模型，则为 true；否则为 false。
        public virtual bool ShowForEdit { get; set; }

        //
        // 摘要:
        //     获取或设置模型的简单显示字符串。
        //
        // 返回结果:
        //     模型的简单显示字符串。
        public virtual string SimpleDisplayText { get; set; }

        //
        // 摘要:
        //     获取一个值，该值指示类型是否可为 null。
        //
        // 返回结果:
        //     如果该类型可为 null，则为 true；否则为 false。
        public bool IsNullableValueType { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示模型是否为复杂类型。
        //
        // 返回结果:
        //     一个值，指示 MVC 框架是否将模型视为复杂类型。
        public virtual bool IsComplexType { get; set; }

        public virtual bool HtmlEncode { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示是否应该使用关联的 HTML 元素呈现模型对象。
        //
        // 返回结果:
        //     如果包含模型对象的关联 HTML 元素应包含在该对象中，则为 true；否则为 false。
        public virtual bool HideSurroundingHtml { get; set; }

        //
        // 摘要:
        //     获取包含有关模型的其他元数据的字典。
        //
        // 返回结果:
        //     包含有关模型的其他元数据的字典。
        public virtual Dictionary<string, object> AdditionalValues { get; }

        //
        // 摘要:
        //     获取或设置一个提示，该提示建议要为此模型使用哪个模板。
        //
        // 返回结果:
        //     一个提示，建议要为此模型使用哪个模板。
        public virtual string TemplateHint { get; set; }

        //
        // 摘要:
        //     获取或设置模型的容器的类型。
        //
        // 返回结果:
        //     模型的容器的类型。
        public string ContainerType { get; set; }

        //
        // 摘要:
        //     获取或设置一个值，该值指示在窗体中回发的空字符串是否应转换为 null。
        //
        // 返回结果:
        //     如果在窗体中回发的空字符串应转换为 null，则为 true；否则为 false。默认值为 true。
        public virtual bool ConvertEmptyStringToNull { get; set; }

        //
        // 摘要:
        //     对模型的容器对象的引用。如果该模型表示属性，则将不为 null。
        public object Container { get; set; }

        //
        // 摘要:
        //     获取或设置模型的说明。
        //
        // 返回结果:
        //     模型的说明。默认值为 null。
        public virtual string Description { get; set; }

        //
        // 摘要:
        //     获取或设置模型的显示格式字符串。
        //
        // 返回结果:
        //     模型的显示格式字符串。
        public virtual string DisplayFormatString { get; set; }

        //
        // 摘要:
        //     获取或设置模型的显示名称。
        //
        // 返回结果:
        //     模型的显示名称。
        public virtual string DisplayName { get; set; }

        //
        // 摘要:
        //     获取或设置模型的编辑格式字符串。
        //
        // 返回结果:
        //     模型的编辑格式字符串。
        public virtual string EditFormatString { get; set; }

        //
        // 摘要:
        //     获取或设置有关数据类型的元信息。
        //
        // 返回结果:
        //     有关数据类型的元信息。
        public virtual string DataTypeName { get; set; }

        //
        // 摘要:
        //     获取或设置可用作水印的值。
        //
        // 返回结果:
        //     水印。
        public virtual string Watermark { get; set; }
    }
}