namespace SmartClient.Core.Interfaces
{
    public interface ITreeListViewModel
    {
        ITreeItemViewModel ActiveRow { get; set; }
        bool ShowDeleted { get; set; }
        void Refresh();
        void DeleteActive();
        void RestoreActive();
    }
}
