const base_url = "https://api.github.com"

let basicInfo = {};
const getBasicInfo = () => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora`)
        .then(function (response) {
            console.log(response.data);
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

}

let statisticInfo = {};
const getStatisticInfo = () => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/stats/contributors`)
        .then(function (response) {
            console.log(response.data);
            statisticInfo = response.data;
        }).catch(function (error) {
            console.log(error);
        });
}

let totalCommits = [];
const getCommits = (pageCounter) => {
    axios.get(`${base_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/commits?page=${pageCounter}`)
        .then(function (response) {
            if (response.data.length !== 0) {
                totalCommits.push(response.data);
                console.log(totalCommits);
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
    for(let commit in totalCommits){
        counter += totalCommits[commit].length;
    }
    commits.innerHTML = counter;
}

window.onload = () => {
    getBasicInfo();
    getStatisticInfo();
    getCommits(1);
}
