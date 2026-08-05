using DevKit.Focus.Sharp;
using DevKit.Focus.WinUi3.Sharp;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace DevKit.Focus.WinUi3.Sharp.Tests;

public class WinUi3FocusContractTests
{
    [Test]
    public async Task For_null_root_throws()
    {
        var action = () => WinUi3KeyboardFocusScope.For(null!);
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task PostFocus_null_dispatcher_throws_before_queueing()
    {
        var coordinator = new KeyboardFocusCoordinator();
        var scope = new DelegateKeyboardFocusScope("test", () => true, () => false, () => true);
        var request = new KeyboardFocusRequest(KeyboardFocusReason.SurfaceEntered);

        var action = () => coordinator.PostFocus((DispatcherQueue)null!, scope, request);

        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task AttachRestoration_null_window_throws()
    {
        var coordinator = new KeyboardFocusCoordinator();
        var action = () => WinUi3KeyboardFocusExtensions.AttachKeyboardFocusRestoration(
            (Window)null!,
            coordinator,
            () => null);

        await Assert.That(action).Throws<ArgumentNullException>();
    }
}
