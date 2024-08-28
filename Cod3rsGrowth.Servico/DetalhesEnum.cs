using System.ComponentModel;
using System.Reflection;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Servico
{
    public static class DetalhesEnum
    {
        public static List<string> ObterDescricaoEnum()
        {
            List<string> naturalidades = new List<string>(); 
            foreach (Naturalidade value in Enum.GetValues(typeof(Naturalidade)))
            {
                FieldInfo field = value.GetType().GetField(value.ToString());
                DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
                naturalidades.Add(attribute == null ? value.ToString() : attribute.Description);
            }
            return naturalidades;
        }
    }
}
