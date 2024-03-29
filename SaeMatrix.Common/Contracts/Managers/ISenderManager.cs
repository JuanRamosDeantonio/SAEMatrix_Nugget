﻿namespace SAE.Matrix.Common.Contracts.Managers
{
    using Entities;

    public interface ISenderManager
    {
        /// <summary>
        /// Metodo encargado de realizar la peticion de envio
        /// </summary>
        /// <typeparam name="T">Tipo generico que define el tipo de contenido</typeparam>
        /// <returns></returns>
        Task<ResponseBase<T>> SendRequest<T>(HttpRequestMessage requestMessage, string clientBase, Action<HttpClient> complement = null);
        /// <summary>
        /// Metodo encargado de construir el mensaje que se envia
        /// </summary>
        /// <typeparam name="T">Tipo generico que define el tipo de contenido</typeparam>
        /// <param name="method">GET,PUT,POST,DELETE</param>
        /// <param name="content">Objeto que define el contenido del mensaje</param>
        /// <param name="configParams">Configuracion del envio</param>
        /// <returns>Mensaje contruido HttpRequestMessage</returns>
        HttpRequestMessage BuildMessageByConfig<T>(HttpMethod method, T content, RequestConfig configParams, bool isStandar = true, bool includeJsonIgnore = false);

        /// <summary>
        /// Obtiene la configuracion apropiada para el envio
        /// </summary>
        /// <param name="configName">Nombre de la configuracion</param>
        /// <returns>Objeto con la configuracion definida</returns>
        RequestConfig GetConfiguration(string configName);

        /// <summary>
        /// Valida la estructura de la respuesta de la solicitud
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseBase"></param>
        /// <param name="responseMessage"></param>
        /// <param name="type"></param>
        /// <param name="contentResponse"></param>
        ResponseBase<T> ValidateResponse<T>(HttpResponseMessage responseMessage, Type type, string contentResponse);
    }

}
