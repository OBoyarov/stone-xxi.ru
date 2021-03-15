Imports System.Net
Imports System.Xml

Public Class ClsCBR

    Public Function GetValCurs(ByVal DateReq As String, Optional ByVal CharCode As String = Nothing) As DataTable
        Dim Url As String = "http://www.cbr.ru/scripts/XML_daily.asp?date_req="
        Dim UrlCnc As String = Url & DateReq
        Dim WC As New WebClient
        Dim Response As String = WC.DownloadString(UrlCnc)
        Dim XmlDoc As New XmlDocument()
        XmlDoc.LoadXml(Response)
        Dim XmlNodes As XmlNodeList
        If Not CharCode Is Nothing Then
            XmlNodes = XmlDoc.SelectNodes("//ValCurs/Valute[CharCode=""" & CharCode & """]")
        Else
            XmlNodes = XmlDoc.SelectNodes("//ValCurs/Valute")
        End If
        Dim DT As DataTable = CreateDataTableFromCBRData()
        For Each x As XmlElement In XmlNodes
            Dim VCharCode As String = x.GetElementsByTagName("CharCode")(0).InnerText
            Dim VValue As Double = CDbl(x.GetElementsByTagName("Value")(0).InnerText)
            DT.Rows.Add(CDate(DateReq), VCharCode, VValue)
        Next
        Return DT
    End Function

    Public Function GetValItems() As DataTable
        Dim Url As String = "http://www.cbr.ru/scripts/XML_valFull.asp"
        Dim WC As New WebClient
        Dim Response As String = WC.DownloadString(Url)
        Dim XmlDoc As New XmlDocument()
        XmlDoc.LoadXml(Response)
        Dim XmlNodes As XmlNodeList
        XmlNodes = XmlDoc.SelectNodes("//Valuta/Item")
        Dim DT As DataTable = CreateDataTableFromCBRItems()
        For Each x As XmlElement In XmlNodes
            If x.GetElementsByTagName("ISO_Num_Code")(0).InnerText.Length > 0 Then
                Dim IName As String = x.GetElementsByTagName("Name")(0).InnerText
                Dim IEngName As String = x.GetElementsByTagName("EngName")(0).InnerText
                Dim INominal As Integer = CInt(x.GetElementsByTagName("Nominal")(0).InnerText)
                Dim IParentCode As String = x.GetElementsByTagName("ParentCode")(0).InnerText
                Dim IISO_Num_Code As Integer = CInt(x.GetElementsByTagName("ISO_Num_Code")(0).InnerText)
                Dim IISO_Char_Code As String = x.GetElementsByTagName("ISO_Char_Code")(0).InnerText
                DT.Rows.Add(IName, IEngName, INominal, IParentCode, IISO_Num_Code, IISO_Char_Code)
            End If
        Next
        Return DT
    End Function

    Private Function CreateDataTableFromCBRData() As DataTable
        Dim DT As DataTable = New DataTable
        DT.TableName = "CBRData"
        DT.Columns.Add("datereq", GetType(Date))
        DT.Columns.Add("charcode", GetType(String))
        DT.Columns.Add("value", GetType(Decimal))
        Return DT
    End Function

    Private Function CreateDataTableFromCBRItems() As DataTable
        Dim DT As DataTable = New DataTable
        DT.TableName = "CBRItems"
        DT.Columns.Add("Name", GetType(String))
        DT.Columns.Add("EngName", GetType(String))
        DT.Columns.Add("Nominal", GetType(Integer))
        DT.Columns.Add("ParentCode", GetType(String))
        DT.Columns.Add("ISO_Num_Code", GetType(Integer))
        DT.Columns.Add("ISO_Char_Code", GetType(String))
        Return DT
    End Function

End Class
