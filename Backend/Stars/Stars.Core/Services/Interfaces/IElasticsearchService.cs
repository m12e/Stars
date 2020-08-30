namespace Stars.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для интеграции с Elasticsearch
	/// </summary>
	public interface IElasticsearchService
	{
		/// <summary>
		/// Создать клиента для подключения к серверу Elasticsearch
		/// </summary>
		void CreateClient();

		/// <summary>
		/// Проиндексировать документ
		/// </summary>
		void IndexDocument<TDocument>(TDocument document)
			where TDocument : class;
	}
}
