Imports Microsoft.VisualBasic

Public Class Int_GP_SEG_DOC
    Dim mId As Long, mId_doc As Long, mFec_reg As Date, mEst_ini As String, mEst_fin As String, mObs_seg As String
    Property Id As Long
        Get
            Return mId
        End Get
        Set(value As Long)
            mId = value
        End Set
    End Property


    Property Id_Doc As Long
        Get
            Return mId_doc
        End Get
        Set(value As Long)
            mId_doc = value
        End Set
    End Property

    Property Fec_Reg As Date
        Get
            Return mFec_reg
        End Get
        Set(value As Date)
            mFec_reg = value
        End Set
    End Property

    Property Est_Ini As String
        Get
            Return mEst_ini
        End Get
        Set(value As String)
            mEst_ini = value
        End Set
    End Property

    Property Est_Fin As String
        Get
            Return mEst_fin
        End Get
        Set(value As String)
            mEst_Fin = value
        End Set
    End Property

    Property Obs_Seg As String
        Get
            Return mObs_seg
        End Get
        Set(value As String)
            mObs_seg = value
        End Set
    End Property
End Class
