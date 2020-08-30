using Stars.Dal.DataModels.Interfaces;

namespace Stars.Dal.DataModels
{
	/// <summary>
	/// Базовый класс для модели данных
	/// </summary>
	public abstract class BaseDataModel : IDataModel
	{
		public int Id { get; set; }
	}
}
