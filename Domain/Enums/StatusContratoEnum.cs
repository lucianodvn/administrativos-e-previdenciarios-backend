namespace Domain.Enums
{
    public enum StatusContratoEnum
    {
        Iniciado = 1,
        EmDia = 2,
        EmAtraso = 3,
        Finalizado = 4
    }
    public static class StatusContratoEnumExtensions
    {
        public static string GetStatusDescricao(this StatusContratoEnum status)
        {
            return status switch
            {
                StatusContratoEnum.Iniciado => "Iniciado",
                StatusContratoEnum.EmDia => "Em Dia",
                StatusContratoEnum.EmAtraso => "Em Atraso",
                StatusContratoEnum.Finalizado => "Finalizado",
                _ => "Desconhecido"
            };
        }

        public static StatusContratoEnum? ToStatusEnum(this string descricao)
        {
            return descricao switch
            {
                "Iniciado" => StatusContratoEnum.Iniciado,
                "Em Dia" => StatusContratoEnum.EmDia,
                "Em Atraso" => StatusContratoEnum.EmAtraso,
                "Finalizado" => StatusContratoEnum.Finalizado,
                _ => null // ou lançar exceção, dependendo do seu controle
            };
        }
    }
}
