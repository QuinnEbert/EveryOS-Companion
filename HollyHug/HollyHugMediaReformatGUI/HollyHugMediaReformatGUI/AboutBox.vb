Public NotInheritable Class AboutBox

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = String.Format("A Product of {0} >> TBRNTech.com", My.Application.Info.CompanyName.ToString)
        Me.TextBoxDescription.Text = My.Application.Info.Description
        Me.TextBoxDescription.Text &= vbNewLine & vbNewLine & "HollyAnn renderings are the product of Firestorm Six of Stormfire Studios:" & vbNewLine & "     http://www.stormfirestudios.ca/" & vbNewLine & "All rights reserved."
        Me.TextBoxDescription.Text &= vbNewLine & vbNewLine & "Ogg123 and OggEnc binaries used in this product are provided in the Cygwin project:" & vbNewLine & "     http://cygwin.org/"
        Me.TextBoxDescription.Text &= vbNewLine & vbNewLine & "OGG container format and Vorbis audio codec are products of the Xiph.Org Foundation:" & vbNewLine & "     http://www.xiph.org/"
        Me.TextBoxDescription.Text &= vbNewLine & vbNewLine & "LEGAL NOTICE FOR SOFTWARE: FFmpeg" & vbNewLine & vbNewLine & "The FFmpeg binary (that may be) contained with this software product is capable of bearing support for the encoding and decoding of audio/visual file formats which may be encumbered by patents held internationally, or in a number of countries.  Despite this capability, the bundled version (or versions) of FFmpeg are compiled with configuration option --enable-gpl, so as to be compliant with FFmpeg's GPL-only patented-format status.  End users may (but are discouraged from) distributing binaries of FFmpeg which do include patent-encumbered codec and/or format support.  We assume no legal responsibility for the use of such formats and codecs with this product."
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
