Public Class Form1

    Dim grades() As Double = {0, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25, 2.5, 2.75, 3.0}
    Dim units() As Double = {0, 2.0, 3.0, 4.0, 5.0}
    Dim gradeList(9) As Double
    Dim unitList(9) As Double

    Public Sub FillComboBoxes()

        For Each unitBox As ComboBox In unitPanel.Controls
            AssignArray(unitBox, 1)
            unitBox.SelectedIndex = 0
        Next

        For Each gradeBox As ComboBox In gradePanel.Controls
            AssignArray(gradeBox, 2)
            gradeBox.SelectedIndex = 0
        Next

    End Sub

    Public Sub AssignArray(cmb As ComboBox, category As Integer)

        If category = 1 Then
            For n = 0 To 4
                cmb.Items.Add(units(n))
            Next
        Else
            For n = 0 To 9
                cmb.Items.Add(grades(n))
            Next
        End If

    End Sub

    Private Sub Form1_Load() Handles MyBase.Load
        FillComboBoxes()
    End Sub

    Private Sub Button3_Click() Handles btnExit.Click
        Close()
    End Sub

    Private Sub Button2_Click() Handles btnReset.Click
        ResetComboBoxes()
        lblGWA.Text = ""

    End Sub

    Public Sub ResetComboBoxes()

        For Each unitBox As ComboBox In unitPanel.Controls
            unitBox.SelectedIndex = 0
        Next

        For Each gradeBox As ComboBox In gradePanel.Controls
            gradeBox.SelectedIndex = 0
        Next

    End Sub

    Private Sub Button1_Click() Handles btnCompute.Click

        PopulateArray()

        Dim totalUnits As Double = 0
        Dim unitXgrade As Double = 0
        Dim gwa As Double = 0

        For idx = 0 To 9
            totalUnits += unitList(idx)
        Next

        For idx = 0 To 9
            unitXgrade += (unitList(idx) * gradeList(idx))
        Next

        gwa = unitXgrade / totalUnits

        lblGWA.Text = gwa.ToString("N2")

    End Sub

    Public Sub PopulateArray()

        Dim idx As Integer = 0
        Dim idy As Integer = 0

        For Each unitBox As ComboBox In unitPanel.Controls
            unitList(idx) = Convert.ToDouble(unitBox.Text)
            idx += 1
        Next

        For Each gradeBox As ComboBox In gradePanel.Controls
            gradeList(idy) = Convert.ToDouble(gradeBox.Text)
            idy += 1
        Next

    End Sub



End Class
