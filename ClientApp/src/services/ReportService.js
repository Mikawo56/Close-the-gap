export async function getAllInfo() {
  const resp = await fetch(
    "https://hitw-closethegap.azurewebsites.net/api/Material/get/all"
  );
  return await resp.json();
}

export async function getDateDonorMaterial(donor, date) {
  const resp = await fetch(
    "https://hitw-closethegap.azurewebsites.net/api/Material/get/report",
    donor,
    date
  );
  return await resp.json();
}
