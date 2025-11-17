<%@ Page Title="Client Resources - Interview Prep" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientResources.aspx.cs" Inherits="RCTemp.ClientResources" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:900px;margin:28px auto;padding:22px;background:#fff;border-radius:6px;box-shadow:0 6px 18px rgba(0,0,0,.06);font-family:'Segoe UI', Roboto, Arial, sans-serif;">
        <h1 style="margin-top:0;">Interview Preparation Tips</h1>
        <p style="color:#555;margin-bottom:18px;">Practical guidance to help candidates present their best selves — preparation, structure, and follow-up.</p>

        <section style="margin-bottom:18px;">
            <h2>Before the Interview</h2>
            <ul>
                <li>Research the company: mission, recent news, products/services, and company culture. Review the job description and match your experience to key responsibilities.</li>
                <li>Prepare examples: Use the STAR method (Situation, Task, Action, Result) to structure answers to behavioral questions.</li>
                <li>Practice common questions (see list below) out loud and time your responses — aim for concise, specific answers (1–2 minutes per example).</li>
                <li>Plan logistics: know the interview location or test your video setup, arrive 10–15 minutes early, and bring copies of your resume.</li>
                <li>Prepare questions to ask the interviewer — this shows interest and helps you evaluate fit.</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>STAR Method (Quick)</h2>
            <ol>
                <li><strong>Situation</strong> — Brief context for the story.</li>
                <li><strong>Task</strong> — What you were expected to accomplish.</li>
                <li><strong>Action</strong> — What you specifically did (focus on "I", not "we").</li>
                <li><strong>Result</strong> — Concrete outcome or learnings (use metrics when possible).</li>
            </ol>
            <p style="font-size:.95rem;color:#444;">Example: "Situation — The team missed a deadline. Task — I needed to get the project back on track. Action — I reorganized priorities, assigned tasks, and communicated daily progress. Result — We delivered two days later and improved our on-time delivery rate by 15%."</p>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Common Interview Questions</h2>
            <ul>
                <li>Tell me about yourself.</li>
                <li>Why are you interested in this role/company?</li>
                <li>Describe a time you faced a challenge at work and how you handled it.</li>
                <li>Give an example of when you worked on a team. What was your role?</li>
                <li>How do you prioritize competing tasks or deadlines?</li>
                <li>What is a professional accomplishment you’re proud of?</li>
                <li>Do you have any questions for us?</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Interview Day Checklist</h2>
            <ul>
                <li>Resume (2–3 printed copies), portfolio or work samples (if applicable).</li>
                <li>Notebook and pen, or a clean digital note setup for remote interviews.</li>
                <li>List of questions for the interviewer (culture, growth, next steps).</li>
                <li>Appropriate attire prepared and comfortable; when in doubt, choose business casual.</li>
                <li>Phone off or on silent; ensure video camera, microphone, and internet are stable for virtual interviews.</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Follow-up Email Templates</h2>
            <h4 style="margin-bottom:6px;">Thank-you email (after interview)</h4>
            <pre style="background:#f6f6f6;padding:10px;border-radius:4px;white-space:pre-wrap;">Hi [Interviewer Name],

Thank you for taking the time to speak with me today about the [Job Title] role. I enjoyed learning about [specific topic] and believe my experience with [brief relevant skill/example] would allow me to contribute to your team.

Please let me know if you need any additional information. I look forward to the next steps.

Best regards,
[Your Name]
</pre>

            <h4 style="margin-bottom:6px;">Follow-up (if you haven't heard back)</h4>
            <pre style="background:#f6f6f6;padding:10px;border-radius:4px;white-space:pre-wrap;">Hi [Hiring Manager Name],

I hope you're well. I wanted to check in regarding the [Job Title] position. I'm still very interested and available to provide any further information.

Thank you for your time,
[Your Name]
</pre>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Resume & Portfolio Tips</h2>
            <ul>
                <li>Keep your resume concise (1–2 pages), highlight measurable achievements rather than responsibilities.</li>
                <li>Tailor the resume summary and skills to the job posting keywords.</li>
                <li>Include links to a professional portfolio, LinkedIn, or code samples (GitHub) where relevant.</li>
                <li>File names for uploads: use a clear format like &quot;Firstname_Lastname_Resume.pdf&quot;.</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Video Interview Best Practices</h2>
            <ul>
                <li>Use a quiet, well-lit location. Position the camera at eye level.</li>
                <li>Dress as you would for an in-person interview and test audio/video in advance.</li>
                <li>Keep your background neutral and remove distractions. Use headphones to reduce echo.</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Additional Resources</h2>
            <ul>
                <li><a href="ResumeTips.aspx">Resume writing tips</a> (sample bullets and templates)</li>
                <li><a href="InterviewPractice.aspx">Mock interview checklist and practice questions</a></li>
                <li><a href="Contact.aspx">Contact your recruiter</a> — we can provide personalized coaching and feedback.</li>
            </ul>
        </section>

        <p style="font-size:13px;color:#666;margin-top:18px;">Tip: practice with a friend or record yourself to review body language and clarity. If you'd like, we can add printable PDF versions of these resources.</p>
    </div>
</asp:Content>