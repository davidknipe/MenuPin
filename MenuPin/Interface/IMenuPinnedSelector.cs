using System;
namespace MenuPin.Interface
{
    public interface IMenuPinnedSelector
    {
        bool IsMenuPinned(string associatedUIUrl);
    }
}
