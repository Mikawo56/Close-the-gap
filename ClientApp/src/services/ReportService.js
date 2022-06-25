export async function getAllInfo() {
  const resp = await fetch(
    "https://hitw-closethegap.azurewebsites.net/api/Material/get/all"
  );
  return await resp.json();
}
