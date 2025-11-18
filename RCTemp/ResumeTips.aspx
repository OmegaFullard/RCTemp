<%@ Page Title="Resume Writing Tips" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResumeTips.aspx.cs" Inherits="RCTemp.ResumeTips" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:900px;margin:28px auto;padding:22px;background:#fff;border-radius:6px;box-shadow:0 6px 18px rgba(0,0,0,.06);font-family:'Segoe UI', Roboto, Arial, sans-serif;">
        <h1 style="margin-top:0;">Resume Writing Tips</h1>
        <p style="color:#555;margin-bottom:18px;">Clear, concise and targeted resumes get interviews. Use the guidance below to polish your resume and increase your chances of being selected.</p>

        <section style="margin-bottom:16px;">
            <h2>1. Format & file</h2>
            <ul>
                <li>Keep it to 1–2 pages for most roles. Use a clean sans-serif font (11–12pt) and consistent spacing.</li>
                <li>Save and deliver as PDF (recommended) or DOCX only if requested. Name files like <code>Firstname_Lastname_Resume.pdf</code>.</li>
                <li>Use bullet lists, clear section headers and a readable margin (0.5&quot;–1&quot;).</li>
            </ul>
        </section>

        <section style="margin-bottom:16px;">
            <h2>2. Header & contact</h2>
            <ul>
                <li>Include full name, city/state, phone, professional email and a LinkedIn URL (or portfolio link).</li>
                <li>Avoid including date of birth, marital status, or unrelated personal info.</li>
            </ul>
        </section>

        <section style="margin-bottom:16px;">
            <h2>3. Professional summary</h2>
            <p style="color:#444">Write a 1–3 line summary focused on what you deliver. Tailor the wording to the job — include title, years of experience and top strengths.</p>
            <p style="font-style:italic;color:#333">Example: "Product-focused software engineer with 6+ years building scalable APIs. Experienced in C#, .NET and cloud deployments; reduced API latency by 40%."</p>
        </section>

        <section style="margin-bottom:16px;">
            <h2>4. Experience — focus on impact</h2>
            <ul>
                <li>List roles in reverse chronological order. For each role include company, location, title and dates.</li>
                <li>Use 3–6 bullets per role. Start each bullet with a strong action verb and include measurable results when possible.</li>
                <li>Prefer results: "Improved X by Y%" over "Responsible for X".</li>
            </ul>
            <h4 style="margin-top:8px;">Before / After example</h4>
            <pre style="background:#f6f6f6;padding:10px;border-radius:4px;white-space:pre-wrap;">
Before:
- Responsible for onboarding new hires and training sessions.

After:
- Designed and delivered onboarding program for 50+ hires, reducing ramp time by 30% and increasing retention by 12% in the first 6 months.
</pre>
        </section>

        <section style="margin-bottom:16px;">
            <h2>5. Skills & keywords (ATS-aware)</h2>
            <ul>
                <li>Include a concise skills section grouped by category (Technical, Tools, Languages).</li>
                <li>Match keywords from the job description — ATS (applicant tracking systems) look for exact terms.</li>
                <li>Avoid keyword stuffing; only list skills you can demonstrate.</li>
            </ul>
        </section>

        <section style="margin-bottom:16px;">
            <h2>6. Education & certifications</h2>
            <ul>
                <li>List degree, school and graduation year (optional for experienced candidates).</li>
                <li>Include relevant certifications with issuing organization and date.</li>
            </ul>
        </section>

        <section style="margin-bottom:16px;">
            <h2>7. Common mistakes to avoid</h2>
            <ul>
                <li>Typos and inconsistent formatting — proofread or ask someone else to review.</li>
                <li>Vague bullets without results or context.</li>
                <li>Including irrelevant or outdated details (e.g., unrelated coursework for senior hires).</li>
            </ul>
        </section>

        <section style="margin-bottom:16px;">
            <h2>8. Quick action-verb list</h2>
            <p style="color:#444; margin-bottom:8px;">Use strong verbs to open bullets:</p>
            <p style="font-size:.95rem;color:#333;">Led · Delivered · Implemented · Optimized · Designed · Scaled · Orchestrated · Reduced · Increased · Automated · Negotiated</p>
        </section>

        <section style="margin-bottom:16px;">
            <h2>9. Resume checklist (before you apply)</h2>
            <ul>
                <li>Is your summary tailored to the job?</li>
                <li>Are bullets measurable and specific?</li>
                <li>Is formatting consistent and file named correctly?</li>
                <li>Did you include relevant keywords from the posting?</li>
            </ul>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Free review & next steps</h2>
            <p>If you'd like a free resume review we offer two options:</p>
            <ol>
                <li>Upload your resume for review: <a href="ResumeReview.aspx">Request a review (upload)</a>.</li>
                <li>Email it to <a href="mailto:resume-review@royalcitytemps.com">resume-review@royalcitytemps.com</a> with the role you’re targeting and 2–3 career highlights.</li>
            </ol>
            <p style="color:#666;margin-top:6px;">We aim to return a short scored summary and recommended edits within 2 business days.</p>
        </section>

        <section style="margin-bottom:18px;">
            <h2>Sample resume template (outline)</h2>
            <pre style="background:#f6f6f6;padding:10px;border-radius:4px;white-space:pre-wrap;">
Full Name
City, State · (555) 555-5555 · email@example.com · linkedin.com/in/you

Professional Summary
- 1–3 lines summarizing experience, skills and impact.

Experience
Company Name — Title
City, ST · MM/YYYY – Present
- Action verb + what you did + measurable result.
- ...
Company Name — Title
City, ST · MM/YYYY – MM/YYYY
- Bullet
- Bullet

Education
Degree, Major — School Name · Year

Skills
- Technical: C#, SQL, .NET
- Tools: Azure, Git, Docker
</pre>
        </section>

        <p style="font-size:13px;color:#666;margin-top:18px;">Want me to add an upload form here (directly on this page) that saves resumes and auto-queues review requests? I can implement that and connect it to the admin review queue.</p>
    </div>
</asp:Content>