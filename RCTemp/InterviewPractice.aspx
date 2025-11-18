<%@ Page Title="Interview Practice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterviewPractice.aspx.cs" Inherits="RCTemp.InterviewPractice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width:1000px;margin:24px auto;font-family:'Segoe UI', Roboto, Arial, sans-serif;">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2>Interview Practice</h2>
            <small class="text-muted">Practice common interview formats: MCQ, STAR behavioral, and coding prompts.</small>
        </div>

        <section style="margin-bottom:18px;padding:16px;border:1px solid #e6e6e6;border-radius:6px;background:#fff;">
            <h3>Quick settings</h3>
            <div style="display:flex;gap:12px;align-items:center;">
                <label>Timer (minutes): <input id="timerMinutes" type="number" min="1" max="120" value="15" style="width:80px" /></label>
                <button id="btnStartTimer" class="btn btn-outline-primary" onclick="startTimer();return false;">Start Timer</button>
                <button id="btnStopTimer" class="btn btn-outline-secondary" onclick="stopTimer();return false;" disabled>Stop</button>
                <div style="margin-left:auto;font-weight:600;">
                    Time remaining: <span id="timeDisplay">--:--</span>
                </div>
            </div>
            <p class="text-muted" style="margin-top:8px;">Use the timer to simulate a timed practice session. You can practice sections independently.</p>
        </section>

        <section id="mcqSection" style="margin-bottom:18px;padding:16px;border:1px solid #e6e6e6;border-radius:6px;background:#fff;">
            <h3>Multiple-choice practice (technical / behavioral)</h3>
            <form id="mcqForm">
                <ol>
                    <li>
                        Which of the following is a proper way to handle a missed deadline?
                        <div><label><input type="radio" name="q1" value="a" /> Blame the team publicly</label></div>
                        <div><label><input type="radio" name="q1" value="b" /> Communicate proactively, propose a recovery plan</label></div>
                        <div><label><input type="radio" name="q1" value="c" /> Ignore and hope it resolves</label></div>
                    </li>
                    <li>
                        In C#, what keyword declares a variable whose value cannot be changed after assignment?
                        <div><label><input type="radio" name="q2" value="a" /> var</label></div>
                        <div><label><input type="radio" name="q2" value="b" /> readonly</label></div>
                        <div><label><input type="radio" name="q2" value="c" /> const</label></div>
                    </li>
                    <li>
                        When writing a resume bullet, the most effective structure is:
                        <div><label><input type="radio" name="q3" value="a" /> Responsibility-oriented statements</label></div>
                        <div><label><input type="radio" name="q3" value="b" /> Action + Context + Result (quantified)</label></div>
                        <div><label><input type="radio" name="q3" value="c" /> Personal hobbies</label></div>
                    </li>
                </ol>

                <div style="margin-top:12px;">
                    <button class="btn btn-primary" onclick="gradeMCQ();return false;">Submit & Score</button>
                    <button class="btn btn-secondary" onclick="resetMCQ();return false;">Reset</button>
                    <span id="mcqResult" style="margin-left:12px;font-weight:600;"></span>
                </div>
            </form>
            <div id="mcqFeedback" style="margin-top:12px;color:#333;"></div>
        </section>

        <section id="starSection" style="margin-bottom:18px;padding:16px;border:1px solid #e6e6e6;border-radius:6px;background:#fff;">
            <h3>Behavioral practice — STAR answers</h3>
            <p>Select a prompt, write your response using the STAR structure, then Save or Clear. You can later review saved answers.</p>

            <div style="display:flex;gap:12px;flex-wrap:wrap;">
                <select id="starPrompt" class="form-select" style="width:60%;">
                    <option value="Describe a time you led a project.">Describe a time you led a project.</option>
                    <option value="Tell me about a time you resolved a conflict at work.">Tell me about a time you resolved a conflict at work.</option>
                    <option value="Give an example of a time you improved a process.">Give an example of a time you improved a process.</option>
                </select>
                <button class="btn btn-outline-secondary" onclick="showStarTemplate();return false;">Show STAR template</button>
                <button class="btn btn-outline-primary" onclick="saveStarAnswer();return false;">Save Answer</button>
                <button class="btn btn-outline-danger" onclick="clearStarAnswer();return false;">Clear</button>
            </div>

            <textarea id="starAnswer" rows="8" class="form-control" style="margin-top:12px;" placeholder="Write your STAR answer here..."></textarea>

            <div style="margin-top:12px;">
                <h5>Saved Answers</h5>
                <ul id="savedStarList"></ul>
            </div>
        </section>

        <section id="codingSection" style="margin-bottom:18px;padding:16px;border:1px solid #e6e6e6;border-radius:6px;background:#fff;">
            <h3>Coding practice</h3>
            <p>Problem: Given an array of integers, return the length of the longest sequence of consecutive integers. (Order not guaranteed.)</p>

            <div style="margin-top:8px;">
                <label>Example input (edit if you want):</label>
                <input id="codingInput" type="text" class="form-control" value="[100,4,200,1,3,2]" />
            </div>

            <div style="margin-top:8px;">
                <label>Your pseudocode / explanation</label>
                <textarea id="codingAnswer" rows="6" class="form-control" placeholder="Explain approach, time & space complexity..."></textarea>
            </div>

            <div style="margin-top:8px;">
                <button class="btn btn-outline-primary" onclick="showCodingSolution();return false;">Show Sample Solution</button>
                <button class="btn btn-outline-success" onclick="runCodingCheck();return false;">Run Quick Check (JS)</button>
                <span id="codingResult" style="margin-left:12px;font-weight:600;"></span>
            </div>

            <pre id="codingSolution" style="background:#f6f6f6;padding:8px;border-radius:4px;margin-top:12px;display:none;"></pre>
        </section>

        <div class="text-end" style="margin-top:20px;">
            <a class="btn btn-secondary" href="ResumeTips.aspx">Back to Resume Tips</a>
            <a class="btn btn-primary" href="ClientResources.aspx">Client Resources</a>
        </div>
    </div>

    <script>
        // Timer
        var timerInterval = null;
        function startTimer() {
            var minutes = parseInt(document.getElementById('timerMinutes').value, 10) || 15;
            var seconds = minutes * 60;
            document.getElementById('btnStartTimer').disabled = true;
            document.getElementById('btnStopTimer').disabled = false;
            updateTimeDisplay(seconds);
            timerInterval = setInterval(function () {
                seconds--;
                if (seconds <= 0) {
                    clearInterval(timerInterval);
                    document.getElementById('btnStartTimer').disabled = false;
                    document.getElementById('btnStopTimer').disabled = true;
                    alert('Time is up!');
                    updateTimeDisplay(0);
                    return;
                }
                updateTimeDisplay(seconds);
            }, 1000);
        }
        function stopTimer() {
            if (timerInterval) clearInterval(timerInterval);
            document.getElementById('btnStartTimer').disabled = false;
            document.getElementById('btnStopTimer').disabled = true;
        }
        function updateTimeDisplay(sec) {
            var m = Math.floor(sec / 60);
            var s = sec % 60;
            document.getElementById('timeDisplay').innerText = (m < 10 ? '0' + m : m) + ':' + (s < 10 ? '0' + s : s);
        }

        // MCQ grading
        function gradeMCQ() {
            var answers = { q1: 'b', q2: 'c', q3: 'b' };
            var total = 0, correct = 0;
            for (var k in answers) {
                total++;
                var els = document.getElementsByName(k);
                var selected = null;
                for (var i = 0; i < els.length; i++) if (els[i].checked) selected = els[i].value;
                if (selected === answers[k]) correct++;
            }
            var pct = Math.round((correct / total) * 100);
            document.getElementById('mcqResult').innerText = 'Score: ' + correct + '/' + total + ' (' + pct + '%)';
            var fb = [];
            if (correct < total) {
                if (document.getElementsByName('q1')[1].checked) fb.push('Good: recovery plan is preferred for missed deadlines.');
                if (document.getElementsByName('q2')[2].checked) fb.push('Correct: const declares an unchangeable value.');
                if (document.getElementsByName('q3')[1].checked) fb.push('Correct: action+context+result is best for resume bullets.');
            } else {
                fb.push('Great job — all answers correct.');
            }
            document.getElementById('mcqFeedback').innerHTML = fb.join('<br/>');
        }
        function resetMCQ() {
            var f = document.getElementById('mcqForm');
            var inputs = f.querySelectorAll('input[type=radio]');
            for (var i = 0; i < inputs.length; i++) inputs[i].checked = false;
            document.getElementById('mcqResult').innerText = '';
            document.getElementById('mcqFeedback').innerHTML = '';
        }

        // STAR behavioral: localStorage based
        function showStarTemplate() {
            var template = "Situation:\n\nTask:\n\nAction:\n\nResult:\n\n";
            var startxt = document.getElementById('starAnswer');
            if (!startxt.value) startxt.value = template;
            else alert('Template added. Edit existing answer or clear first.');
        }
        function saveStarAnswer() {
            if (!('localStorage' in window)) { alert('Local storage not available.'); return; }
            var prompt = document.getElementById('starPrompt').value;
            var answer = document.getElementById('starAnswer').value.trim();
            if (!answer) { alert('Write your answer first.'); return; }
            var list = JSON.parse(localStorage.getItem('starAnswers') || '[]');
            list.unshift({ prompt: prompt, answer: answer, saved: new Date().toISOString() });
            localStorage.setItem('starAnswers', JSON.stringify(list));
            loadSavedStar();
            alert('Saved locally. You can review or edit later.');
        }
        function clearStarAnswer() {
            document.getElementById('starAnswer').value = '';
        }
        function loadSavedStar() {
            var list = JSON.parse(localStorage.getItem('starAnswers') || '[]');
            var ul = document.getElementById('savedStarList');
            ul.innerHTML = '';
            for (var i = 0; i < list.length; i++) {
                var li = document.createElement('li');
                li.style.marginBottom = '8px';
                li.innerHTML = '<strong>' + escapeHtml(list[i].prompt) + '</strong><br/>' +
                    '<pre style="background:#f6f6f6;padding:8px;border-radius:4px;white-space:pre-wrap;">' + escapeHtml(list[i].answer) + '</pre>' +
                    '<button class="btn btn-sm btn-outline-primary" onclick="useSaved(' + i + ');return false;">Load</button> ' +
                    '<button class="btn btn-sm btn-outline-danger" onclick="deleteSaved(' + i + ');return false;">Delete</button>';
                ul.appendChild(li);
            }
        }
        function useSaved(idx) {
            var list = JSON.parse(localStorage.getItem('starAnswers') || '[]');
            if (list[idx]) {
                document.getElementById('starPrompt').value = list[idx].prompt;
                document.getElementById('starAnswer').value = list[idx].answer;
            }
        }
        function deleteSaved(idx) {
            var list = JSON.parse(localStorage.getItem('starAnswers') || '[]');
            list.splice(idx, 1);
            localStorage.setItem('starAnswers', JSON.stringify(list));
            loadSavedStar();
        }

        // coding sample: show solution and run a basic check
        function showCodingSolution() {
            var sol = "Sample approach (JS):\\n" +
                "function longestConsecutive(nums) {\\n" +
                "  const set = new Set(nums);\\n" +
                "  let max = 0;\\n" +
                "  for (let n of set) {\\n" +
                "    if (!set.has(n - 1)) {\\n" +
                "      let cur = n;\\n" +
                "      while (set.has(cur + 1)) cur++;\\n" +
                "      max = Math.max(max, cur - n + 1);\\n" +
                "    }\\n" +
                "  }\\n" +
                "  return max;\\n" +
                "}";
            var el = document.getElementById('codingSolution');
            el.style.display = 'block';
            el.textContent = sol;
        }

        function runCodingCheck() {
            var input = document.getElementById('codingInput').value.trim();
            try {
                // simple parse of array like [1,2,3]
                var arr = JSON.parse(input.replace(/(\d+)(?=,|\])/g, function(m){return m;}));
                if (!Array.isArray(arr)) throw 'Invalid input';
                // run sample algorithm here
                var set = new Set(arr);
                var max = 0;
                set.forEach(function(n) {
                    if (!set.has(n - 1)) {
                        var cur = n;
                        while (set.has(cur + 1)) cur++;
                        max = Math.max(max, cur - n + 1);
                    }
                });
                document.getElementById('codingResult').innerText = 'Result: longest sequence length = ' + max;
            } catch (ex) {
                document.getElementById('codingResult').innerText = 'Error parsing input. Use format like [100,4,200,1,3,2]';
            }
        }

        function escapeHtml(str) {
            return String(str).replace(/[&<>"'`]/g, function (s) {
                return ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;', '`': '&#96;' })[s];
            });
        }

        // initialize saved answers on load
        window.addEventListener('load', function () {
            loadSavedStar();
            updateTimeDisplay(0);
        });
    </script>
</asp:Content>