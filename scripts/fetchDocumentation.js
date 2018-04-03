const base_url = "https://script.googleusercontent.com"

let basicInfo = {};
const getDocumentsInfo = () => {
    axios.get(`${base_url}/macros/echo?user_content_key=pQv4I-i3HkR2YtMeR59llQm0m7JELyQf-hueFut5fk0RG8PMj4JhZNaqyuHZmeGqMlwha5Zu8ldd6HsM-u_1bEx5S2TkCxLbm5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnNnZ00wgiIYnBgciUyKcabn8OT5CsSrjUFcSe_QqaJKJTeLw5iscrUgCbddvEgp78vKfVnhjI6Uu&lib=MGukpczu3yrghHV9zyxgsmsh00DPSBbB3`)
        .then(function (response) {
            console.log(response.data);
            basicInfo = response.data;
            setDocumentsDynamicData();
        }).catch(function (error) {
            console.log(error);
        });
}

const setDocumentsDynamicData = () => {
    setEpsDocuments()
    setMdsDocuments()
    setRelease1Planning()
    setRelease1Review()
}

const setEpsDocuments = () => {
    var epsObj = basicInfo.engenharia_de_produto_de_software
    for (i in epsObj) {

      var doc =
      `<a href="${epsObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${epsObj[i].name}</h5>
          <small>${epsObj[i].last_update}</small>
        </div>
        <p class="mb-1">${epsObj[i].description}</p>
        <small>${epsObj[i].progress}</small>
      </a>
      `
      $("#eps-list").append(doc);
    }
}

const setMdsDocuments = () => {
    var mdsObj = basicInfo.metodo_de_desenvolvimento_de_software
    for (i in mdsObj) {

      var doc =
      `<a href="${mdsObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${mdsObj[i].name}</h5>
          <small>${mdsObj[i].last_update}</small>
        </div>
        <p class="mb-1">${mdsObj[i].description}</p>
        <small>${mdsObj[i].progress}</small>
      </a>
      `
      $("#mds-list").append(doc);
    }
}

const setRelease1Planning = () => {
    var r1PlanningObj = basicInfo.release_1.sprint_planning
    for (i in r1PlanningObj) {

      var doc =
      `<a href="${r1PlanningObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${r1PlanningObj[i].name}</h5>
          <small>${r1PlanningObj[i].last_update}</small>
        </div>
        <p class="mb-1">${r1PlanningObj[i].description}</p>
        <small>${r1PlanningObj[i].progress}</small>
      </a>
      `
      $("#release-1-planning").append(doc);
    }
}

const setRelease1Review = () => {
    var r1ReviewObj = basicInfo.release_1.sprint_review
    for (i in r1ReviewObj) {

      var doc =
      `<a href="${r1ReviewObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${r1ReviewObj[i].name}</h5>
          <small>${r1ReviewObj[i].last_update}</small>
        </div>
        <p class="mb-1">${r1ReviewObj[i].description}</p>
        <small>${r1ReviewObj[i].progress}</small>
      </a>
      `
      $("#release-1-review").append(doc);
    }
}

window.onload = () => {
    getDocumentsInfo();
}
