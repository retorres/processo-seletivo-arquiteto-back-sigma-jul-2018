namespace GP.Api.AspNet.Models.PatrimonioControllerModels
{
    public class CriacaoPatrimonioInput
    {
        /// <summary>
        /// Id do modelo deste patrimonio
        /// </summary>
        public long ModeloId { get; set; }
        /// <summary>
        /// Nome do Patrimonio
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição do patrimonio
        /// </summary>
        public string Descricao { get; set; }
    }
}
