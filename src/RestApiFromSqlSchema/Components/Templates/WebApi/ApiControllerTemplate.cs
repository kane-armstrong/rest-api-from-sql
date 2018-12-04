using System.Collections.Generic;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class ApiControllerTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public bool IncludeUniqueKeyActions { get; set; }
        public IList<GetByIdApiActionTemplate> GetByUniqueKeyTemplates { get; set; }
        public IList<EditApiActionTemplate> EditByUniqueKeyTemplates { get; set; }
        public IList<DeleteApiActionTemplate> DeleteByUniqueKeyTemplates { get; set; }

        public ListApiActionTemplate ListApiActionTemplate { get; set; }
        public GetByIdApiActionTemplate GetByIdApiActionTemplate { get; set; }
        public CreateApiActionTemplate CreateApiActionTemplate { get; set; }
        public EditApiActionTemplate EditApiActionTemplate { get; set; }
        public DeleteApiActionTemplate DeleteApiActionTemplate { get; set; }
    }
}