

export interface Stock {
  $id:string|null;
  $values:StockResponse[]|null;
}
export interface Broker {
  $id:string|null;
  $values:BrokerResponse[]|null;
}

export interface Client {
  $id:string|null;
  $values:ClientResponse[]|null;
}


export class SaveOrder{
  stockID: number | null;
  price: number | null;
  quantity: number | null;
  commission: number | null;
  brokerId: number | null;
  personID: number | null;
}
export interface StockResponse{
  $id:string|null;
  id: number | null;
  name: string | null;
  price: number | null;
}

export class BrokerResponse{
  $id:string|null;
  id: number | null;
  name: string | null;
   constructor($id: string,id: number, name: string) {
    this.id = id;
    this.name = name;
    this.$id=$id;

  }
}

export class ClientResponse{
  $id:string|null;
  id: number | null;
  name: string | null;
  constructor( $id: string,id: number, name: string) {
    this.id = id;
    this.name = name;
    this.$id=$id;
  }
}
