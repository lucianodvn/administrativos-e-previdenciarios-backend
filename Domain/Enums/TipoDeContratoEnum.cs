namespace Domain.Enums
{
    public enum TipoDeContratoEnum
    {
        ProcuracaoAdvAdulto = 1,
        ProcuracaoAdvMenor = 2,
        DeclaracaoPobreza = 3,
        ContratoHonorario = 4
    }
    public static class TipoDeContratoEnumExtensions
    {
        public static string GetTipoDescricao(this TipoDeContratoEnum status)
        {
            return status switch
            {
                TipoDeContratoEnum.ProcuracaoAdvAdulto => "Contrato",
                TipoDeContratoEnum.ProcuracaoAdvMenor => "Contrato Menor de Idade",
                TipoDeContratoEnum.DeclaracaoPobreza => "Declaração de Pobreza",
                TipoDeContratoEnum.ContratoHonorario => "Contrato Honorários",
                _ => "Desconhecido"
            };
        }

        public static TipoDeContratoEnum? ToTipoDeContratoEnum(this string descricao)
        {
            return descricao switch
            {
                "Contrato" => TipoDeContratoEnum.ProcuracaoAdvAdulto,
                "Contrato Menor de Idade" => TipoDeContratoEnum.ProcuracaoAdvMenor,
                "Declaração de Pobreza" => TipoDeContratoEnum.DeclaracaoPobreza,
                "Contrato Honorários" => TipoDeContratoEnum.ContratoHonorario,
                _ => null // ou lançar exceção, dependendo do seu controle
            };
        }
    }
}
