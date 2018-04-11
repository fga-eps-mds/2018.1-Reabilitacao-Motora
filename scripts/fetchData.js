function reverseString(s) {
    return s.split("").reverse().join("");
}

const token_api = reverseString("fb4d5a12cb16327536d9a8dbba29d7f75e42f6bf");
const base_url = "https://api.github.com"


let basicInfo = {};
const getBasicInfo = () => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            basicInfo = response.data;
            setBasicDynamicData();
        }).catch(function (error) {
            console.log(error);
        });
}

const setBasicDynamicData = () => {

    //forks
    let forks = document.getElementById("forks");
    forks.innerHTML = basicInfo.forks_count;

    //language
    let language = document.getElementById("language");
    language.innerHTML = basicInfo.language;

    //issues
    let issues = document.getElementById("issues");
    issues.innerHTML = basicInfo.open_issues;

}

let statisticInfo = {};
const getStatisticInfo = () => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/stats/contributors`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            console.log(response.data);
            statisticInfo = response.data;
            setTopCommiter();
        }).catch(function (error) {
            console.log(error);
        });
}


const setTopCommiter = () => {
    let topCommit = -1;
    let topCommitter = "";
    let topLines = 0;
    let topAvatar = "";
    for (let user in statisticInfo) {
        if (statisticInfo[user].weeks.slice(-2)[0].c > topCommit) {
            topCommit = statisticInfo[user].weeks.slice(-2)[0].c;
            topCommitter = statisticInfo[user].author.login;
            topLines = statisticInfo[user].weeks.slice(-2)[0].a + statisticInfo[user].weeks.slice(-2)[0].d;
            topAvatar = statisticInfo[user].author.avatar_url;
        }
    }
    let div = document.getElementById("top-committer");
    let avatar = document.getElementById("top-avatar");
    let divCommmit = document.getElementById("top-commit");
    let divLines = document.getElementById("top-lines");
    let divLink = document.getElementById("top-link");

    div.innerHTML = topCommitter;
    divCommmit.innerHTML = topCommit;
    divLines.innerHTML = topLines;
    avatar.src = topAvatar;
    divLink.href = `https://github.com/${topCommitter}`;
}

let totalCommits = [];
const getCommits = (pageCounter) => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/commits?page=${pageCounter}`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            if (response.data.length !== 0) {
                totalCommits.push(response.data);
                getCommits(pageCounter + 1);
            } else {
                setCommitData();
            }
        }).catch(function (error) {
            console.log(error);
        });
}

const setCommitData = () => {
    let commits = document.getElementById("commits");
    let counter = 0;
    for (let commit in totalCommits) {
        counter += totalCommits[commit].length;
    }
    commits.innerHTML = counter;

    const template = (author, message, date, avatar_url) => {
        return (
            `
                <div class="project-item-user">
                    <div class="user-avatar"><img src="${avatar_url}" alt="avatar"></div>
                    <div class="user-info"><span class="name">${author}</span></div>
                </div>
                <div class="project-item-title"><span class="name">${message}</span></div>
                <div class="project-item-date"><span class="date">${date}</span></div>
            `
        )
    }

    for (let i = 0; i < 5; i++) {
        let author = totalCommits[0][i].commit.author.name;
        let message = totalCommits[0][i].commit.message;
        let date = totalCommits[0][i].commit.author.date;
        let avatar_url = totalCommits[0][i].author.avatar_url;
        let list = document.getElementById("project-list");
        let oneElement = document.createElement("div");
        oneElement.className = "project-item";
        oneElement.innerHTML = template(author, message, date, avatar_url);
        list.appendChild(oneElement);
    }

}


const startChart = () => {
    var ctx = document.getElementById("commit-chart").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
}

window.onload = () => {
    getBasicInfo();
    getStatisticInfo();
    getCommits(1);
    startChart();
}
