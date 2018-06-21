let basicRepoInfo = {};
const getRepoDocInfo = () => {
    axios.get(`${base_url}/macros/echo?user_content_key=FyNWg9LkaMnO14W_e0dnhTu95p7BERQMDbXdEc4Nrrbht7JFNH29JKUUeNPo5Ynm1wosRm8NvSMpR78UGMf5L_ISfh6EJ907m5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnGKFP4WoNvAgWxqvMojZ24jF3pqp3Yp2cyWA69fFqpDwSf7E4jQwwEOWwHl9XLcByOSrwyx_nfSR&lib=MNpFeaSB2qFfJBFJ1m63-3SnJ73Ww1NkL`)
        .then(function (response) {
            basicRepoInfo = response.data;
            setRepoData();
        }).catch(function (error) {
            console.log(error);
        });
}

const setRepoData = () => {
    setDoxygen()
    setPolicies()
}

const setDoxygen = () => {
    var epsObj = basicRepoInfo.doxygen
    for (i in epsObj) {

      var doc =
      `<a href="${epsObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${epsObj[i].name}</h5>
        </div>
        <p class="mb-1">${epsObj[i].description}</p>
        <small>${epsObj[i].progress}</small>
      </a>
      `
      $("#doxygen-list").append(doc);
    }
}

const setPolicies = () => {
    var mdsObj = basicRepoInfo.policies
    for (i in mdsObj) {

      var doc =
      `<a href="${mdsObj[i].url_markdown}" class="list-group-item list-group-item-action flex-column align-items-start">
        <div class="d-flex w-100 justify-content-between">
          <h5 class="mb-1">${mdsObj[i].name}</h5>
        </div>
        <p class="mb-1">${mdsObj[i].description}</p>
        <small>${mdsObj[i].progress}</small>
      </a>
      `
      $("#policies-list").append(doc);
    }
}

