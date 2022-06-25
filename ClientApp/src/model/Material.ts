export interface Material {
  id: string;
  serialNumber: string;
  model: string;
  grade: string;
  assetTAg: string;
  type: string;
  brand: string;
  component: Dictionary;
  defect: Array<string>;
  reconditionner: Dictionary;
  donnor: string;
  collectionDate: Date;
}

interface Dictionary {
  key: string;
  value: string;
}
