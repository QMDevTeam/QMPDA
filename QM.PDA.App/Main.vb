Imports System.Text
Imports QM.PDA.BO
Imports QM.PDA.BO.Context
Imports QM.PDA.Screens


Module Main

#Region " Properties "

    Private Enum ExecutionFase
        None
        StudySelection
        UserLogin
        SiteSelection
        QuestionnaireSetSelection
        ActionSelection
        SubjectSelection
        QuestionnaireSelection
        QuestionnaireInstanceSelection
        SectionSelection
        SectionExecution
    End Enum

#End Region

#Region " Public Methods "

    Public Sub Main()


        '---------------.
        ' Initialization \
        '---------------------------------------------------------------------
        ' Get the PDA Identification
        PDAName = Net.Dns.GetHostName
        Dim serialNumber As New StringBuilder
        Try
            If iPAQUtil.iPAQGetSerialNumber(serialNumber) Then PDASerialNumber = serialNumber.ToString Else PDASerialNumber = ""
        Catch
            PDASerialNumber = CStr(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\QM", "SN", Nothing))
            PDASerialNumber = CStr(IIf(PDASerialNumber Is Nothing, "", PDASerialNumber))
        End Try



        ' Show the Blank background screen
        Dim blank As New Blank()
        blank.Show()
        Application.DoEvents()
        '---------------------------------------------------------------------



        '-----------------------------.
        ' Start with user interaction  \
        '-----------------------------------------------------------------
        Dim currentExecutionFase As ExecutionFase = PDA.ExecutionFase.None
        Dim formResult As FormResult


        Do

            Select Case currentExecutionFase

                Case ExecutionFase.None

                    formResult = Screens.FormResult.Next
                    currentExecutionFase = ExecutionFase.StudySelection
                    blank.Clear()




                Case ExecutionFase.StudySelection ' Prompt the user for the Study

                    ' If there is only one Study, set it as the Current Study, else ask the user.
                    Dim studies As List(Of BO.Study) = BO.Study.GetAll
                    If studies.Count = 1 Then
                        CurrentStudy = studies(0)

                    Else
                        Cursor.Current = Cursors.Default
                        Dim study As New Study()
                        study.studies = studies
                        Dim studyFormResult As FormResult = study.ShowForm()
                        study.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If studyFormResult <> Screens.FormResult.Skip Then formResult = studyFormResult
                    End If


                    Select Case formResult
                        Case Screens.FormResult.ExitApplication : Exit Do
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.None
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.UserLogin
                    End Select




                Case ExecutionFase.UserLogin ' Promt the user for a login

                    CurrentSite = Nothing
                    CurrentQuestionnaireSet = Nothing
                    CurrentQuestionnaire = Nothing
                    CurrentSection = Nothing

                    ' ViCo: Show the ViCo specific login form
                    Cursor.Current = Cursors.Default
                    Dim login As New ViCoLogin()
                    Dim loginFormResult As FormResult = login.ShowForm()
                    login.Dispose()
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()

                    If loginFormResult <> Screens.FormResult.Skip Then formResult = loginFormResult


                    Select Case formResult
                        Case Screens.FormResult.ExitApplication : Exit Do
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.SiteSelection
                    End Select




                Case ExecutionFase.SiteSelection ' Prompt the user for the Site

                    ' If there is only one Site, set it as the Current Site, else ask the user.
                    Dim sites As List(Of BO.Site) = BO.Site.GetAll()
                    If sites.Count = 1 Then
                        CurrentSite = sites(0)

                    Else
                        Cursor.Current = Cursors.Default
                        Dim site As New Site()
                        site.sites = sites
                        Dim siteFormResult As FormResult = site.ShowForm()
                        site.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If siteFormResult <> Screens.FormResult.Skip Then formResult = siteFormResult
                    End If


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.QuestionnaireSetSelection
                    End Select




                Case ExecutionFase.QuestionnaireSetSelection ' Prompt the user for the Questionnaire Set

                    ' If there is only one valid Questionnaire Set, set it as the Current Questionnaire Set, else ask the user.
                    Dim questionnaireSets As List(Of BO.QuestionnaireSet) = BO.QuestionnaireSet.GetAllValid()
                    If questionnaireSets.Count = 1 Then
                        CurrentQuestionnaireSet = questionnaireSets(0)

                    Else
                        Cursor.Current = Cursors.Default
                        blank.ShowWaitMessage()
                        Application.DoEvents()
                        Dim questionnaireSet As New QuestionnaireSet()
                        questionnaireSet.QuestionnaireSets = questionnaireSets
                        Dim questionnaireSetFormResult As FormResult = questionnaireSet.ShowForm()
                        blank.HideWaitMessage()
                        questionnaireSet.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If questionnaireSetFormResult <> Screens.FormResult.Skip Then formResult = questionnaireSetFormResult
                    End If


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.SiteSelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.ActionSelection
                    End Select




                Case ExecutionFase.ActionSelection ' Prompt the user for the Action to perform

                    Cursor.Current = Cursors.Default
                    Dim action As New Action()
                    Dim actionFormResult As FormResult = action.ShowForm()
                    action.Dispose()
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()

                    If actionFormResult <> Screens.FormResult.Skip Then formResult = actionFormResult


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.QuestionnaireSetSelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.SubjectSelection
                    End Select




                Case ExecutionFase.SubjectSelection ' Prompt the user for the Subject

                    Select Case CurrentAction.Value
                        Case UserAction.CreateSubject
                            CurrentSubject = CurrentQuestionnaireSet.CreateSubject()
                            CurrentQuestionnaireSet.ExecuteOnNewSubjectProcedure()

                        Case UserAction.ModifySubject ' Show the subject selection form.

                            Cursor.Current = Cursors.Default
                            Dim subject As New Subject()
                            Dim subjectFormResult As FormResult = subject.ShowForm()
                            subject.Dispose()
                            Cursor.Current = Cursors.WaitCursor
                            Application.DoEvents()

                            If subjectFormResult <> Screens.FormResult.Skip Then formResult = subjectFormResult

                        Case UserAction.ViewReport

                            Cursor.Current = Cursors.Default
                            Dim reportList As New ReportList()
                            formResult = reportList.ShowForm()

                            If Engine.SubjectSelectionPending Then
                                Engine.ExecutePendingSubjectSelection()
                                formResult = Screens.FormResult.Next
                            Else
                                currentExecutionFase = ExecutionFase.ActionSelection
                            End If

                    End Select


                    ' If there is a specified New Subject Section for the study, go to it.
                    If CurrentAction.Value = UserAction.CreateSubject AndAlso CurrentQuestionnaireSet.NewSubjectSectionID.HasValue Then

                        CurrentSection = New BO.Section(CurrentQuestionnaireSet.NewSubjectSectionID.Value)
                        CurrentQuestionnaire = New BO.Questionnaire(CurrentSection.QuestionnaireID)
                        CurrentQuestionnaire.CreateRecord()
                        CurrentSection.CreateRecord()

                        currentExecutionFase = ExecutionFase.SectionExecution

                    Else ' Else, continue to the next selection screen.

                        Select Case formResult
                            Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                            Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                            Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.ActionSelection
                            Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        End Select

                    End If




                Case ExecutionFase.QuestionnaireSelection ' Prompt the user for the Questionnaire

                    ' Clear the Current Questionnaire and Section
                    CurrentQuestionnaire = Nothing
                    CurrentSection = Nothing


                    ' If there is only one valid Questionnaire, set it as the Current Questionnaire, else ask the user.
                    Dim questionnaires As List(Of BO.Questionnaire) = BO.Questionnaire.GetAllValid(CurrentQuestionnaireSet.QuestionnaireSetID)
                    If questionnaires.Count = 1 Then
                        CurrentQuestionnaire = questionnaires(0)

                    Else
                        Cursor.Current = Cursors.Default
                        blank.ShowWaitMessage()
                        Application.DoEvents()
                        Dim questionnaire As New Questionnaire()
                        questionnaire.Questionnaires = questionnaires
                        Dim questionnaireFormResult As FormResult = questionnaire.ShowForm()
                        blank.HideWaitMessage()
                        questionnaire.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If questionnaireFormResult <> Screens.FormResult.Skip Then formResult = questionnaireFormResult
                    End If

                    ' If a Questionnaire was selected and it doesn't support Multiple Instances then create its Data Record
                    If CurrentQuestionnaire IsNot Nothing AndAlso Not CurrentQuestionnaire.MultipleInstances Then CurrentQuestionnaire.CreateRecord()


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.ChangeSubject : currentExecutionFase = ExecutionFase.ActionSelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.ActionSelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.QuestionnaireInstanceSelection
                    End Select




                Case ExecutionFase.QuestionnaireInstanceSelection ' Prompt the user for the Questionnaire Instance (if applicable)

                    ' Clear the Current Section
                    CurrentSection = Nothing


                    ' If the Current Questionnaire doesn't support multiple instances then continue, else prompt the user.
                    If CurrentQuestionnaire.MultipleInstances Then
                        Cursor.Current = Cursors.Default
                        blank.ShowWaitMessage()
                        Application.DoEvents()
                        Dim questionnaireInstance As New QuestionnaireInstance()
                        Dim questionnaireInstanceFormResult As FormResult = questionnaireInstance.ShowForm()
                        blank.HideWaitMessage()
                        questionnaireInstance.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If questionnaireInstanceFormResult <> Screens.FormResult.Skip Then formResult = questionnaireInstanceFormResult
                    End If


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.ChangeSubject : currentExecutionFase = ExecutionFase.ActionSelection
                        Case Screens.FormResult.ChangeQuestionnaire : currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.SectionSelection
                    End Select




                Case ExecutionFase.SectionSelection ' Prompt the user for the Section

                    ' Clear the Current Section
                    CurrentSection = Nothing


                    ' If there is only one valid Section, set it as the Current Section, else ask the user.
                    Dim sections As List(Of BO.Section) = BO.Section.GetAllValid(CurrentQuestionnaire.QuestionnaireID)
                    If sections.Count = 1 Then
                        CurrentSection = sections(0)

                    Else
                        Cursor.Current = Cursors.Default
                        blank.ShowWaitMessage()
                        Application.DoEvents()
                        Dim section As New Section()
                        section.Sections = sections
                        Dim sectionFormResult As FormResult = section.ShowForm()
                        blank.HideWaitMessage()
                        section.Dispose()
                        Cursor.Current = Cursors.WaitCursor
                        Application.DoEvents()

                        If sectionFormResult <> Screens.FormResult.Skip Then formResult = sectionFormResult
                    End If

                    ' If a Section was selected then create its Data Record
                    If CurrentSection IsNot Nothing Then CurrentSection.CreateRecord()


                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.ChangeSubject : currentExecutionFase = ExecutionFase.ActionSelection
                        Case Screens.FormResult.ChangeQuestionnaire : currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Screens.FormResult.Back : currentExecutionFase = ExecutionFase.QuestionnaireInstanceSelection
                        Case Screens.FormResult.Next : currentExecutionFase = ExecutionFase.SectionExecution
                    End Select




                Case ExecutionFase.SectionExecution ' Execute the Current Section

                    Cursor.Current = Cursors.Default
                    formResult = ExecuteCurrentSection()
                    Cursor.Current = Cursors.WaitCursor
                    Application.DoEvents()

                    Select Case formResult
                        Case Screens.FormResult.ChangeStudy : currentExecutionFase = ExecutionFase.StudySelection
                        Case Screens.FormResult.ChangeSubject : currentExecutionFase = ExecutionFase.ActionSelection
                        Case Screens.FormResult.ChangeQuestionnaire : currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        Case Screens.FormResult.Logout : currentExecutionFase = ExecutionFase.UserLogin
                        Case Else : currentExecutionFase = ExecutionFase.SectionSelection : formResult = Screens.FormResult.Back
                    End Select


                    ' If the user finished the Section and the whole Questionnaire is complete then...
                    If formResult = Screens.FormResult.Back AndAlso CurrentQuestionnaire.IsComplete Then

                        ' If the Questionnaire supports multiple instances, return to the Questionnaire Instace Selection screen.
                        If CurrentQuestionnaire.MultipleInstances Then
                            currentExecutionFase = ExecutionFase.QuestionnaireInstanceSelection

                        Else ' Else, return to the Questionnaire Selection screen.
                            currentExecutionFase = ExecutionFase.QuestionnaireSelection
                        End If
                    End If

            End Select

        Loop
        '-----------------------------------------------------------------

    End Sub

#End Region

#Region " Private Methods "

    Private Function ExecuteCurrentSection() As FormResult

        ' Start the Section execution sequence.
        Engine.Start()


        Dim screen As Screens.BaseScreen
        Dim screenResult As Screens.FormResult = FormResult.Next
        Dim interruptScreenLoop As Boolean = False

        Do

            ' If the screen is not a NOP screen
            If CurrentScreen.Type.ToUpper <> "NOP" Then

                ' Get the current Screen's Template
                screen = CType(Activator.CreateInstance(Type.GetType(CurrentScreen.ScreenTemplate.DotNETClassName, True)), Screens.BaseScreen)

                ' Show the Form
                Cursor.Current = Cursors.Default
                screen.LoadScreen(CurrentScreen)
                screenResult = screen.ShowForm()
                screen.Dispose()
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()

            End If



            Select Case screenResult

                Case Screens.FormResult.Next ' If the user asks for the Next Screen...
                    Engine.GoToNextScreen()

                Case Screens.FormResult.Back ' If the user asks for the Previous Screen...
                    Engine.GoToPreviousScreen()

                Case Else ' If the user chooses any other option, it will interrupt the loop.
                    interruptScreenLoop = True

            End Select

        Loop Until CurrentScreen Is Nothing Or interruptScreenLoop


        ' Finish the Section execution sequence.
        Engine.Finish(interruptScreenLoop)


        'Return the last screen result
        Return screenResult

    End Function

#End Region

End Module
