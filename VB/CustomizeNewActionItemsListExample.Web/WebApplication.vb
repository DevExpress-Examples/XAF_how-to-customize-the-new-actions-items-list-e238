﻿Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo

Namespace CustomizeNewActionItemsListExample.Web
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    Partial Public Class CustomizeNewActionItemsListExampleAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As CustomizeNewActionItemsListExample.Module.CustomizeNewActionItemsListExampleModule

        Public Sub New()
            InitializeComponent()
            LinkNewObjectToParentImmediately = False
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.AllowFilterControlHierarchy = True
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.MaxFilterControlHierarchyDepth = 3
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.AllowFilterControlHierarchyDefault = True
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.MaxHierarchyDepthDefault = 3
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(GetDataStoreProvider(args.ConnectionString, args.Connection), True)
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
            Dim application As System.Web.HttpApplicationState = If(System.Web.HttpContext.Current IsNot Nothing, System.Web.HttpContext.Current.Application, Nothing)
            Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
            If application IsNot Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
                dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
            Else
                dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
                If application IsNot Nothing Then
                    application("DataStoreProvider") = dataStoreProvider
                End If
            End If
            Return dataStoreProvider
        End Function
        Private Sub CustomizeNewActionItemsListExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New CustomizeNewActionItemsListExample.Module.CustomizeNewActionItemsListExampleModule()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' CustomizeNewActionItemsListExampleAspNetApplication
            ' 
            Me.ApplicationName = "CustomizeNewActionItemsListExample"
            Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
