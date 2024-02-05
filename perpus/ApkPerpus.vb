Public Class ApkPerpus
    ' Struktur data untuk menyimpan informasi buku
    Public Class Buku
        Public Property ID As Integer
        Public Property Judul As String
        Public Property Pengarang As String
        Public Property Tersedia As Boolean
    End Class

    ' List untuk menyimpan daftar buku
    Private daftarBuku As New List(Of Buku)

    Private Sub FormPeminjamanBuku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inisialisasi daftar buku
        daftarBuku.Add(New Buku With {.ID = 1, .Judul = "Harry Potter", .Pengarang = "J.K. Rowling", .Tersedia = True})
        daftarBuku.Add(New Buku With {.ID = 2, .Judul = "Lord of the Rings", .Pengarang = "J.R.R. Tolkien", .Tersedia = True})
        daftarBuku.Add(New Buku With {.ID = 3, .Judul = "To Kill a Mockingbird", .Pengarang = "Harper Lee", .Tersedia = False})
    End Sub

    ' Tombol untuk mencari buku berdasarkan ID
    Private Sub ButtonCari_Click(sender As Object, e As EventArgs) Handles ButtonCari.Click
        Dim idCari As Integer
        If Integer.TryParse(TextBoxIDCari.Text, idCari) Then
            Dim buku As Buku = CariBukuByID(idCari)

            If buku IsNot Nothing Then
                TextBoxJudul.Text = buku.Judul
                TextBoxPengarang.Text = buku.Pengarang
                If buku.Tersedia Then
                    LabelStatus.Text = "Tersedia"
                Else
                    LabelStatus.Text = "Dipinjam"
                End If
            Else
                MessageBox.Show("Buku dengan ID tersebut tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("ID yang dimasukkan tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    ' Tombol untuk meminjam buku
    Private Sub ButtonPinjam_Click(sender As Object, e As EventArgs) Handles ButtonPinjam.Click
        Dim idPinjam As Integer = Integer.Parse(TextBoxIDCari.Text)
        Dim buku As Buku = CariBukuByID(idPinjam)

        If buku IsNot Nothing AndAlso buku.Tersedia Then
            buku.Tersedia = False
            LabelStatus.Text = "Dipinjam"
            MessageBox.Show("Buku berhasil dipinjam.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf buku IsNot Nothing AndAlso Not buku.Tersedia Then
            MessageBox.Show("Buku ini sudah dipinjam.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Buku dengan ID tersebut tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Tombol untuk mengembalikan buku
    Private Sub ButtonKembalikan_Click(sender As Object, e As EventArgs) Handles ButtonKembalikan.Click
        Dim idKembali As Integer = Integer.Parse(TextBoxIDCari.Text)
        Dim buku As Buku = CariBukuByID(idKembali)

        If buku IsNot Nothing AndAlso Not buku.Tersedia Then
            buku.Tersedia = True
            LabelStatus.Text = "Tersedia"
            MessageBox.Show("Buku berhasil dikembalikan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf buku IsNot Nothing AndAlso buku.Tersedia Then
            MessageBox.Show("Buku ini sudah tersedia.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Buku dengan ID tersebut tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Fungsi untuk mencari buku berdasarkan ID
    Private Function CariBukuByID(id As Integer) As Buku
        Return daftarBuku.FirstOrDefault(Function(buku) buku.ID = id)
    End Function


End Class
