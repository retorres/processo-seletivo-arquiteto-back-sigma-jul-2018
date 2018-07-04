namespace GP.Api.AspNet.Models.ModeloControllerModels
{
    public class CriacaoModeloInput
    {
        /// <summary>
        /// Id da marca que este modelo pertence
        /// </summary>
        public long MarcaId { get; set; }

        /// <summary>
        /// Nome do modelo
        /// </summary>
        public string Nome { get; set; }
    }
}
