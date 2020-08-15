namespace ProgrammingBatch.Pong.DesignPattern.Command
{
    public interface ICommand
    {
        void Execute(object commandValue = null);
        //void Undo(); is it needed?
    }
}