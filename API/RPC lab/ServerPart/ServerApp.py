import xmlrpc.server
import pandas as pd


class MyServer:
    
    def head(self):
        wc=pd.read_csv(r"C:\Users\lapat\Desktop\4 курс 1 семестр\RPC lab\ServerPart\worldcities.csv")
        return  str(wc.head(10))
    def tail(self):
        wc=pd.read_csv(r"C:\Users\lapat\Desktop\4 курс 1 семестр\RPC lab\ServerPart\worldcities.csv")
        return  str(wc.tail(10))
server = xmlrpc.server.SimpleXMLRPCServer(("localhost", 8000))
server.register_instance(MyServer())
server.serve_forever()
