using System;
using System.ComponentModel;

namespace Nava.Processo.Seletivo.WebApi.Controllers
{
    public static class EnumUtil
    {
        // Obtido de https://stackoverflow.com/questions/4367723/get-enum-from-description-attribute
        public static T ObterEnumPelaDescricao<T>(string descricao) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == descricao.ToUpper())
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == descricao)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Não encontrado", nameof(descricao));
        }
    }
}
