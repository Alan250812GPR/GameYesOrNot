using Plugin.Maui.Audio;

namespace GameYesNot;

public partial class MainPage : ContentPage
{
    private readonly IAudioManager audioManager;
    private IAudioPlayer yesPlayer;
    private IAudioPlayer noPlayer;

    public MainPage()
    {
        InitializeComponent();
        audioManager = new AudioManager();
        LoadAudioPlayers();
    }

    private void LoadAudioPlayers()
    {
        try
        {
            yesPlayer = audioManager.CreatePlayer("si.mp3");
            noPlayer = audioManager.CreatePlayer("No.mp3");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar audios: {ex.Message}");
        }
    }

    private async void OnYesButtonClicked(object sender, EventArgs e)
    {
        if (yesPlayer?.IsPlaying == true)
        {
            yesPlayer.Stop();
            yesPlayer.Seek(0);
        }
        
        yesPlayer?.Play();

        YesButton.ScaleTo(0.95, 100);
        await YesButton.ScaleTo(1.0, 100);
    }

    private async void OnNoButtonClicked(object sender, EventArgs e)
    {
        if (noPlayer?.IsPlaying == true)
        {
            noPlayer.Stop();
            noPlayer.Seek(0);
        }
        
        noPlayer?.Play();

        NoButton.ScaleTo(0.95, 100);
        await NoButton.ScaleTo(1.0, 100);
    }
}