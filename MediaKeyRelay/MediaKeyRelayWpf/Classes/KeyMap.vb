Public Class KeyMap
    Public Enum VirtualKeyCodes
        VK_MEDIA_PLAY_PAUSE = 179
        VK_MEDIA_STOP = 178
        VK_MEDIA_NEXT_TRACK = 176
        VK_MEDIA_PREV_TRACK = 177
        VK_MEDIA_VOL_MUTE = 173
        VK_MEDIA_VOL_UP = 174
        VK_MEDIA_VOL_DOWN = 175
    End Enum

    Public Enum MPCCommandCodes
        Play = 887
        Pause = 888
        PlayPause = 889
        [Stop] = 890
        Previous = 921
        [Next] = 922
        VolumeUp = 907
        VolumeDown = 908
        VolumeMute = 909
    End Enum

    Public Class VLCCommandCodes
        Public Const Play As String = "pl_play"
        Public Const Pause As String = "pl_pause"
        Public Const [Stop] As String = "pl_stop"
        Public Const [Next] As String = "pl_next"
        Public Const Previous As String = "pl_previous"
    End Class

    Public Shared VKtoMPC As New Dictionary(Of Integer, Integer) From {
        {VirtualKeyCodes.VK_MEDIA_PLAY_PAUSE, MPCCommandCodes.PlayPause},
        {VirtualKeyCodes.VK_MEDIA_NEXT_TRACK, MPCCommandCodes.Next},
        {VirtualKeyCodes.VK_MEDIA_PREV_TRACK, MPCCommandCodes.Previous},
        {VirtualKeyCodes.VK_MEDIA_STOP, MPCCommandCodes.Stop},
        {VirtualKeyCodes.VK_MEDIA_VOL_MUTE, MPCCommandCodes.VolumeMute},
        {VirtualKeyCodes.VK_MEDIA_VOL_UP, MPCCommandCodes.VolumeUp},
        {VirtualKeyCodes.VK_MEDIA_VOL_DOWN, MPCCommandCodes.VolumeDown}
    }

    Public Shared VKtoVLC As New Dictionary(Of Integer, String) From {
        {VirtualKeyCodes.VK_MEDIA_PLAY_PAUSE, VLCCommandCodes.Pause},
        {VirtualKeyCodes.VK_MEDIA_NEXT_TRACK, VLCCommandCodes.Next},
        {VirtualKeyCodes.VK_MEDIA_PREV_TRACK, VLCCommandCodes.Previous},
        {VirtualKeyCodes.VK_MEDIA_STOP, VLCCommandCodes.Stop}
    }
End Class
