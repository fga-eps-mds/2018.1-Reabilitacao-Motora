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
    // main title
    document.title = basicInfo.name;
    let mainTitle = document.getElementById("main-title");
    mainTitle.innerHTML = basicInfo.name;

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
            statisticInfo = response.data;
        }).catch(function (error) {
            console.log(error);
        });
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
}



window.onload = () => {
    getBasicInfo();
    getStatisticInfo();
    getCommits(1);
}
