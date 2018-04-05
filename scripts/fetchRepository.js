const base_url = "https://script.googleusercontent.com"

let basicInfo = {};
const getDocumentsInfo = () => {
    axios.get(`${base_url}/macros/echo?user_content_key=FyNWg9LkaMnO14W_e0dnhTu95p7BERQMDbXdEc4Nrrbht7JFNH29JKUUeNPo5Ynm1wosRm8NvSMpR78UGMf5L_ISfh6EJ907m5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnGKFP4WoNvAgWxqvMojZ24jF3pqp3Yp2cyWA69fFqpDwSf7E4jQwwEOWwHl9XLcByOSrwyx_nfSR&lib=MNpFeaSB2qFfJBFJ1m63-3SnJ73Ww1NkL`)
        .then(function (response) {
            console.log(response.data);
            basicInfo = response.data;
            setDocumentsDynamicData();
        }).catch(function (error) {
            console.log(error);
        });
}

const setDocumentsDynamicData = () => {
    setDoxygen()
    setPolicies()
}

const setDoxygen = () => {
    var epsObj = basicInfo.doxygen
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
      $("#doxygen-list").append(doc);
    }
}

const setPolicies = () => {
    var mdsObj = basicInfo.policies
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
      $("#policies-list").append(doc);
    }
}

window.onload = () => {
    getDocumentsInfo();
}
