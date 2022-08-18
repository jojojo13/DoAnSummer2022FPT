using ModelAuto;
using ModelAuto.Models;
using Services.CommonModel;
using Services.CommonServices;
using Services.ResponseModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
    public class Request : IRequest
    {
        private ICommon c = new CommonImpl();
        public bool ActiveOrDeActiveRequest(List<int> list, int status, string actionBy)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        List<int> ListRCID = new List<int>();
                        ListRCID = GetListRequestByID(item).Select(x => x.Id).ToList();
                        foreach (var rcId in ListRCID)
                        {
                            RcRequest tobj = new RcRequest();
                            tobj = context.RcRequests.Where(x => x.Id == rcId).FirstOrDefault();
                            tobj.Status = status;
                            if (status == 4 || status == 5)
                            {
                                ICommon c = new CommonImpl();
                                EmployeeCv em = context.EmployeeCvs.Where(x => x.EmployeeId == tobj.SignId).FirstOrDefault();
                                if (em != null)
                                {
                                    if (em.EmailWork != "" && em.EmailWork != null)
                                    {
                                        MailDTO mailDTO = new MailDTO();
                                        string statusName = status == 4 ? "Approved" : status == 5 ? "Rejected" : "";
                                        //mailDTO.content = "Your Request '" + tobj.Name + "' has been " + statusName + " by " + actionBy + " If there is feedback, please give feedback to the manager";
                                        mailDTO.content = "<p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-left:190.35pt;'><span style='font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p><p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";'><span style='font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p><p style='margin:0in;margin-bottom:.05pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-top:.2pt;margin-right:0in;margin-left:0in;'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p><table style=\"border: none;margin-left:5.75pt;border-collapse:collapse;\">    <tbody>        <tr>            <td style=\"width: 65.05pt;padding: 0in;height: 11.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:10.0pt;line-height:10.25pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">C&ocirc;ng ty</span></strong></p>            </td>            <td style=\"width: 361.85pt;padding: 0in;height: 11.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:16.7pt;line-height:10.25pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">C&ocirc;ng ty Cổ phần CPSUM22</span></strong></p>            </td>        </tr>        <tr>            <td style=\"width: 65.05pt;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:10.0pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">Địa chỉ</span></strong></p>            </td>            <td style=\"width: 361.85pt;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:16.7pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Tầng 5, Green Office- Meco Complex, 102 Trường Chinh, Đống Đa, H&agrave; Nội</span></p>            </td>        </tr>        <tr>            <td style=\"width: 65.05pt;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:10.0pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">Website</span></strong></p>            </td>            <td style=\"width: 361.85pt;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:16.7pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><a href=\"http://google.com.vn\"><span style=\"font-size:13px;\">http://</span><span style=\"font-size:13px;\">google</span><span style=\"font-size:13px;\">.</span><span style=\"font-size:13px;\">com.</span><span style=\"font-size:13px;\">vn</span></a></p>            </td>        </tr>        <tr>            <td style=\"width: 65.05pt;padding: 0in;height: 11.35pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:10.0pt;line-height:10.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">Hot line</span></strong></p>            </td>            <td style=\"width: 361.85pt;padding: 0in;height: 11.35pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:16.7pt;line-height:10.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">098.939.6668</span></p>            </td>        </tr>    </tbody></table><p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-top:.1pt;'><span style='font-size:18px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p><p style='margin:0in;margin-bottom:.0001pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";margin-top:4.65pt;margin-right:0in;margin-left:28.0pt;'><span style=\"font-size:13px;\">Ứng vi&ecirc;n: <strong>"+123123+" </strong></span></p><p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-top:9.05pt;margin-right:16.0pt;margin-left:28.0pt;line-height:106%;'>Thay mặt c&ocirc;ng ty, bộ phận Nh&acirc;n sự gửi cảm ơn bạn đ&atilde; d&agrave;nh thời gian tham gia phỏng v&acirc;́n vị trí Lập tr&igrave;nh vi&ecirc;n của c&ocirc;ng ty.</p><p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-top:8.25pt;margin-right:0in;margin-left:28.0pt;'>Tr&acirc;n trọng gửi tới bạn lời mời l&agrave;m việc ch&iacute;nh thức của c&ocirc;ng ty:</p><ol style=\"list-style-type: decimal;\">    <li><span style=\"font-size:13px;\">Chức danh/vị trí c&ocirc;ng việc: <strong>Lập tr&igrave;nh&nbsp;vi&ecirc;n</strong></span></li>    <li><span style=\"font-size:13px;\">Bộ phận l&agrave;m việc: <strong>Triển khai dự &aacute;n</strong></span></li>    <li><span style=\"font-size:13px;\">Số điện thoại li&ecirc;n hệ khi cần th&ecirc;m th&ocirc;ng tin: <strong>Mr Lĩnh 0343 954 654</strong></span></li>    <li><span style=\"font-size:13px;\">Ng&agrave;y bắt đầu l&agrave;m việc dự kiến: <strong>08/08/2022</strong></span></li>    <li><span style=\"font-size:13px;\">Thời gian thử việc: <strong>02&nbsp;th&aacute;ng</strong></span></li>    <li><span style=\"font-size:13px;\">Nơi l&agrave;m việc: <strong>H&agrave; nội</strong></span></li></ol><p style='margin:0in;margin-bottom:.0001pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";'><strong>&nbsp;</strong></p><p style='margin:0in;margin-bottom:.05pt;font-size:13px;font-family:\"Arial\",\"sans-serif\";margin-top:.2pt;margin-right:0in;margin-left:0in;'><strong><span style=\"font-size:7px;\">&nbsp;</span></strong></p><table style=\"margin-left:10.6pt;border-collapse:collapse;border:none;\">    <tbody>        <tr>            <td style=\"width: 35.8pt;border-top: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-bottom: none;background: rgb(156, 194, 228);padding: 0in;height: 12.95pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">STT</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: 1pt solid rgb(188, 213, 237);border-left: none;border-bottom: none;border-right: 1pt solid rgb(188, 213, 237);background: rgb(156, 194, 228);padding: 0in;height: 12.95pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">C&aacute;c khoản thu nhập/ ph&uacute;c lợi</span></strong></p>            </td>            <td style=\"width: 72.05pt;border-top: 1pt solid rgb(188, 213, 237);border-left: none;border-bottom: none;border-right: 1pt solid rgb(188, 213, 237);background: rgb(156, 194, 228);padding: 0in;height: 12.95pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:19.0pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">Chi tiết</span></strong></p>            </td>            <td style=\"width: 40.6pt;border-top: 1pt solid rgb(188, 213, 237);border-left: none;border-bottom: none;border-right: 1pt solid rgb(188, 213, 237);background: rgb(156, 194, 228);padding: 0in;height: 12.95pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.95pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><strong><span style=\"font-size:13px;\">ĐVT</span></strong></p>            </td>            <td style=\"width: 216.1pt;border-top: 1pt solid rgb(188, 213, 237);border-left: none;border-bottom: none;border-right: 1pt solid rgb(188, 213, 237);background: rgb(156, 194, 228);padding: 0in;height: 12.95pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">Ghi ch&uacute;</span></strong></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.6pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">1</span></em></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.6pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">HĐLĐ thử vi&ecirc;̣c</span></em></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.6pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.6pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.6pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:53.9pt;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Thu nhập thử việc (2 tháng)</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:22.0pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">8.000.000</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Hưởng 85% lương chính thức</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">2</span></em></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">HĐLĐ chính thức</span></em></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Khi thử việc đạt y&ecirc;u cầu</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Lương NET</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:22.0pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">9.500.000</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:12.7pt;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Hình thức trả lương: Ti&ecirc;̀n măt/chuy&ecirc;̉n khoản qua t&agrave;i khoản Ng&agrave;y c&ocirc;ng dự tính: 24 c&ocirc;ng</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.4pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">3</span></em></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.4pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">Thưởng h&agrave;ng năm</span></em></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.4pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.4pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.4pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Lương tháng thứ 13</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.45pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Thưởng kinh doanh</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:11.45pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.45pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:.2pt;margin-right:11.5pt;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">T&ugrave;y theo hoạt động c&ocirc;ng ty v&agrave; đ&oacute;ng g&oacute;p của nh&acirc;n vi&ecirc;n</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;background: rgb(156, 194, 228);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">#</span></strong></p>            </td>            <td colspan=\"4\" style=\"width: 481.8pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);background: rgb(156, 194, 228);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">C&aacute;c điều khoản chung</span></strong></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.0pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><em><span style=\"font-size:13px;\">I</span></em></strong></p>            </td>            <td colspan=\"4\" style=\"width: 481.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.0pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">Phụ cấp</span></em></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">1</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-image: initial;border-left: none;padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:.1pt;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Phụ c&acirc;́p xăng xe điện thoại</span></p>            </td>            <td style=\"width: 72.05pt;border-top: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-image: initial;border-left: none;padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:.1pt;margin-right:0in;margin-bottom:.0001pt;margin-left:21.4pt;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Kh&ocirc;ng</span></p>            </td>            <td style=\"width: 40.6pt;border-top: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-image: initial;border-left: none;padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:.1pt;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-image: initial;border-left: none;padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:.1pt;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.65pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời ky</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">2</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Phụ c&acirc;́p chức vụ</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:21.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Kh&ocirc;ng</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời ky</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 23.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.25pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">3</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">C&ocirc;ng tác phí</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:26.7pt;line-height:11.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-indent:-9.15pt;'><span style=\"font-size:13px;\">Khi phát sinh</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23.25pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời ky</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11.75pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><em><span style=\"font-size:13px;\">II</span></em></strong></p>            </td>            <td colspan=\"4\" style=\"width: 481.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11.75pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">Ph&uacute;c lợi</span></em></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">1</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Thưởng Tết &Acirc;m lịch</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">2</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Thưởng tết Dương lịch</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">3</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Nghỉ mát/Team Building</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">4</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Việc hiếu hỷ</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.55pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">5</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.55pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Review lương</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.55pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.55pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Một năm 2 kỳ review lương</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.25pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">6</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:30.3pt;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Chúc mừng CBNV nữ (8/3, 20/10)</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:9.45pt;margin-bottom:.0001pt;margin-left:0in;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:right;'><span style=\"font-size:13px;\">VNĐ</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 23pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">7</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Trang thiết bị l&agrave;m việc</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">8</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Khám sức khỏe định</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.5pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Theo quy định của c&ocirc;ng ty trong từng thời kỳ</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">9</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Bảo hi&ecirc;̉m X&atilde; hội</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:28.3pt;margin-bottom:.0001pt;margin-left:28.4pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";text-align:center;'><span style=\"font-size:13px;\">C&oacute;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:11px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 11.7pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.15pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Khi k&yacute; hợp đồng ch&iacute;nh thức với c&ocirc;ng ty</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11.75pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><em><span style=\"font-size:13px;\">III</span></em></strong></p>            </td>            <td colspan=\"4\" style=\"width: 481.8pt;border: none;background: rgb(188, 213, 237);padding: 0in;height: 11.75pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.6pt;line-height:10.75pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><em><span style=\"font-size:13px;\">Thời gian l&agrave;m vi&ecirc;̣c</span></em></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.25pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">1</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.35pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Từ thứ 2 đến thứ 6</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.9pt;vertical-align: top;\">                <p style='margin-top:.05pt;margin-right:67.6pt;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.5pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Từ 8h00 đến 12h, từ 13h30 đến 17h30</span></p>            </td>        </tr>        <tr>            <td style=\"width: 35.8pt;border-right: 1pt solid rgb(188, 213, 237);border-bottom: 1pt solid rgb(188, 213, 237);border-left: 1pt solid rgb(188, 213, 237);border-image: initial;border-top: none;padding: 0in;height: 22.85pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.2pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><strong><span style=\"font-size:13px;\">2</span></strong></p>            </td>            <td style=\"width: 153.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.85pt;vertical-align: top;\">                <p style='margin-top:.05pt;margin-right:21.65pt;margin-bottom:.0001pt;margin-left:5.35pt;line-height:11.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">L&agrave;m việc 2 ng&agrave;y thứ 7 trong th&aacute;ng</span></p>            </td>            <td style=\"width: 72.05pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.85pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 40.6pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.85pt;vertical-align: top;\">                <p style='margin-top:0in;margin-right:0in;margin-bottom:.0001pt;margin-left:0in;line-height:normal;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style='font-size:12px;font-family:\"Times New Roman\",\"serif\";'>&nbsp;</span></p>            </td>            <td style=\"width: 216.1pt;border-top: none;border-left: none;border-bottom: 1pt solid rgb(188, 213, 237);border-right: 1pt solid rgb(188, 213, 237);padding: 0in;height: 22.85pt;vertical-align: top;\">                <p style='margin-top:.05pt;margin-right:67.6pt;margin-bottom:.0001pt;margin-left:5.15pt;line-height:11.4pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'><span style=\"font-size:13px;\">Từ 8h00 đến 12h, từ 13h30 đến 17h30</span></p>            </td>        </tr>    </tbody></table><p style='margin:0in;margin-bottom:.0001pt;font-size:15px;font-family:\"Arial\",\"sans-serif\";'>&nbsp;</p>";
                                        mailDTO.subject = "Notice the status of your recruitment request";
                                        mailDTO.fromMail = "aisolutionssum22@gmail.com";
                                        mailDTO.pass = "miztlfnbereqmeko";
                                        mailDTO.listCC = new List<string>();
                                        mailDTO.listBC = new List<string>();
                                        mailDTO.tomail = em?.EmailWork;
                                        c.sendMail(mailDTO);
                                    }
                                }
                            }
                        }
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRequest(List<int> list)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        RcRequest tobj = new RcRequest();
                        tobj = context.RcRequests.Where(x => x.Id == item).FirstOrDefault();
                        context.RcRequests.Remove(tobj);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<RequestResponseServices> GetAllRequest(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequests.Where(x => x.Rank == 1)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                from pro in context.OtherLists.Where(x => x.Id == r.Project).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    department = o.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = o.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = e.FullName,
                                    signID = r.SignId,
                                    OrgnizationName = o.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name,
                                    projectID = pro.Id,
                                    projectname = pro.Name
                                };
                    return query.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
                return new List<RequestResponseServices>();
            }
        }



        public List<RequestResponseServices> GetAllRequestByFillter(int index, int size, string Code, string Name, string OrgName, string PositionName, int Quantity, string Status, string HrInchange, DateTime CreateOn, DateTime DeadLine, string otherSkill)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<RequestResponseServices> list = new List<RequestResponseServices>();
                    var query = from r in context.RcRequests.Where(x => x.Rank == 1)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                from pro in context.OtherLists.Where(x => x.Id == r.Project).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    department = o.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = o.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = e.FullName,
                                    signID = r.SignId,
                                    OrgnizationName = o.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name,
                                    projectID = pro.Id,
                                    projectname = pro.Name
                                };
                    list = query.ToList();

                    if (!Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.code.ToLower().Contains(Code.ToLower())).ToList();
                    }
                    if (!Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.name.ToLower().Contains(Name.ToLower())).ToList();
                    }
                    if (!OrgName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.department.ToLower().Contains(OrgName.ToLower())).ToList();
                    }
                    if (!PositionName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.position.ToLower().Contains(PositionName.ToLower())).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("draft"))
                    {
                        list = list.Where(x => x.StatusID == 1).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("submited"))
                    {
                        list = list.Where(x => x.StatusID == 2).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("cancel"))
                    {
                        list = list.Where(x => x.StatusID == 3).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("approved"))
                    {
                        list = list.Where(x => x.StatusID == 4).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("rejected"))
                    {
                        list = list.Where(x => x.StatusID == 5).ToList();
                    }
                    if (!HrInchange.Trim().Equals(""))
                    {
                        list = list.Where(x => x.HrInchangeId != null).ToList();
                        list = list.Where(x => x.HrInchange.ToLower().Contains(HrInchange.ToLower())).ToList();
                    }
                    if (Quantity != 0)
                    {
                        list = list.Where(x => x.quantity == Quantity).ToList();
                    }
                    if (CreateOn.Year != 1000)
                    {
                        list = list.Where(x => x.createdOn?.ToString("dd/MM/YYYY") == CreateOn.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (DeadLine.Year != 1000)
                    {
                        list = list.Where(x => x.Deadline?.ToString("dd/MM/YYYY") == DeadLine.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (!otherSkill.Trim().Equals(""))
                    {
                        list = list.Where(x => x.otherSkill != null).ToList();
                        list = list.Where(x => x.otherSkillname.ToLower().Contains(otherSkill.ToLower())).ToList();
                    }
                    return list.OrderByDescending(x => x.id).Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
                return new List<RequestResponseServices>();
            }
        }

        public List<RequestResponseServices> GetChildRequestById(int ID)
        {
            List<RequestResponseServices> listReturn = new List<RequestResponseServices>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    var query = from r in context.RcRequests.Where(x => x.ParentId == ID)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    department = o.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = o.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = e.FullName,
                                    signID = r.SignId,
                                    OrgnizationName = o.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name
                                };
                    listReturn = query.ToList();
                    return listReturn;
                }
            }
            catch
            {
                return listReturn.ToList();
            }
        }

        public RequestResponseServices GetRequestByID(int ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from r in context.RcRequests.Where(x => x.Id == ID)
                                from p in context.Positions.Where(x => x.Id == r.PositionId).DefaultIfEmpty()
                                from typ in context.OtherLists.Where(x => x.Id == r.Type).DefaultIfEmpty()
                                from Project in context.OtherLists.Where(x => x.Id == r.Project).DefaultIfEmpty()
                                from Org in context.Orgnizations.Where(x => x.Id == r.OrgnizationId).DefaultIfEmpty()
                                from Sign in context.Employees.Where(x => x.Id == r.SignId).DefaultIfEmpty()
                                from Lev in context.OtherLists.Where(x => x.Id == r.Level).DefaultIfEmpty()
                                from Hr in context.Employees.Where(x => x.Id == r.HrInchange).DefaultIfEmpty()
                                from skill in context.OtherLists.Where(x => x.Id == r.OtherSkill).DefaultIfEmpty()
                                from rele in context.OtherLists.Where(x => x.Id == r.RequestLevel).DefaultIfEmpty()
                                select new RequestResponseServices
                                {
                                    id = r.Id,
                                    code = r.Code,
                                    name = r.Name,
                                    requestLevel = rele.Name,
                                    department = Org.Name,
                                    position = p.Name,
                                    positionID = r.PositionId,
                                    quantity = r.Number,
                                    createdOn = r.EffectDate,
                                    createdOnString = Convert.ToDateTime(r.EffectDate).ToString("dd/M/yyyy"),
                                    Deadline = r.ExpireDate,
                                    DeadlineString = Convert.ToDateTime(r.ExpireDate).ToString("dd/M/yyyy"),
                                    Office = Org.Address,
                                    StatusID = r.Status,
                                    Status = r.Status == 1 ? "Draft" : r.Status == 2 ? "Submited" : r.Status == 3 ? "Cancel" : r.Status == 4 ? "Approved" : r.Status == 5 ? "Rejected" : "",
                                    parentId = r.ParentId,
                                    rank = r.Rank,
                                    note = r.Note,
                                    comment = r.Comment,
                                    HrInchangeId = r.HrInchange,
                                    HrInchange = Hr.FullName,
                                    signID = r.SignId,
                                    typeID = r.RequestLevel,
                                    typename = rele.Name,
                                    OrgnizationName = Org.Name,
                                    OrgnizationID = r.OrgnizationId,
                                    projectname = Project.Name,
                                    projectID = r.Project,
                                    experience = r.YearExperience,
                                    level = r.Level,
                                    levelName = Lev.Name,
                                    CreateBy = r.CreateBy,
                                    CreateDate = r.CreateDate,
                                    UpdateBy = r.UpdateBy,
                                    UpdateDate = r.UpdateDate,
                                    otherSkill = r.OtherSkill,
                                    otherSkillname = skill.Name
                                };
                    return query.FirstOrDefault();
                }
            }
            catch
            {
                return new RequestResponseServices();
            }
        }

        public bool InsertRequest(RcRequest T)
        {
            RcRequest rc = new RcRequest();
            rc.Name = T.Name;
            rc.EffectDate = T.EffectDate;
            rc.ExpireDate = T.ExpireDate;
            rc.Number = T.Number;
            rc.OrgnizationId = T.OrgnizationId;
            rc.SignId = T.SignId;
            rc.Note = T.Note;
            rc.Number = T.Number;
            rc.YearExperience = T.YearExperience;
            rc.Project = T.Project;
            rc.PositionId = T.PositionId;
            rc.Type = T.Type;
            rc.Comment = T.Comment;
            rc.ParentId = T.ParentId;
            rc.Level = T.Level;
            rc.RequestLevel = T.RequestLevel;
            rc.Budget = T.Budget;
            rc.Status = T.Status;
            rc.Comment = T.Comment;
            rc.CreateDate = DateTime.Now;
            rc.CreateBy = T.CreateBy;
            rc.OtherSkill = T.OtherSkill;
            if (rc.ParentId != null && rc.ParentId > 0)
            {
                rc.Rank = GetRequestByID((int)rc.ParentId).rank + 1;
            }
            else
            {
                rc.Rank = 1;
            }
            rc.Code = c.autoGenCode("Rc_Request", rc.Rank, "Rank", rc.ParentId);
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.RcRequests.Add(rc);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModifyRequest(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();
                    rc.Name = T.Name;
                    rc.EffectDate = T.EffectDate;
                    rc.ExpireDate = T.ExpireDate;
                    rc.Number = T.Number;
                    rc.OrgnizationId = T.OrgnizationId;
                    rc.SignId = T.SignId;
                    rc.Note = T.Note;
                    rc.Number = T.Number;
                    rc.YearExperience = T.YearExperience;
                    rc.Project = T.Project;
                    rc.PositionId = T.PositionId;
                    rc.Type = T.Type;
                    rc.Comment = T.Comment;
                    rc.Level = T.Level;
                    rc.Budget = T.Budget;
                    rc.UpdateDate = DateTime.Now;
                    rc.UpdateBy = T.UpdateBy;
                    rc.HrInchange = T.HrInchange;
                    rc.OtherSkill = T.OtherSkill;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool SendComment(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.Comment = T.Comment;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool setHrInchange(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.HrInchange = T.HrInchange;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //for check total request
        public List<RcRequest> GetListRequestByID(int ID)
        {
            List<RcRequest> list = new List<RcRequest>();
            DataTable dt = DAOContext.GetListRequestByID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RcRequest o = new RcRequest();
                DataRow row = dt.Rows[i];
                o.Id = Convert.ToInt32(row["ID"].ToString());
                o.Number = Convert.ToInt32(row["Number"].ToString());
                list.Add(o);
            }
            return list;
        }

        public int getTotalRequestRecord(string column, int? signID)
        {
            string query = "select count(*) COUNT from RC_Request where Rank=1 and " + column + " = " + signID;
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }
    }
}
