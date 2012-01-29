import string
import cgi
import time
from os import curdir
from os import sep
from BaseHTTPServer import BaseHTTPRequestHandler
from BaseHTTPServer import HTTPServer

class MyHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        try:
            print "self.path: "+self.path
            if (self.path == "/"):
                f = open(curdir + sep + "index.html")
                self.send_response(302)
                self.send_header('Location',	'/mypower')
                self.end_headers()
                self.wfile.write(f.read())
                f.close()
                return
            elif (self.path == "/mypower"):
                self.send_response(200)
                self.send_header('Content-type',	'text/html')
                self.end_headers()
                self.wfile.write("Foobars!")
            return
        except IOError:
            self.send_error(404,'File Not Found: %s' % self.path)
    def do_POST(self):
        global rootnode
        try:
            ctype, pdict = cgi.parse_header(self.headers.getheader('content-type'))
            if ctype == 'multipart/form-data':
                query=cgi.parse_multipart(self.rfile, pdict)
            self.send_response(301)
            self.end_headers()
            upfilecontent = query.get('upfile')
            print "filecontent", upfilecontent[0]
            self.wfile.write("<HTML>POST OK.<BR><BR>");
            self.wfile.write(upfilecontent[0]);
        except :
            pass

def main():
    try:
        server = HTTPServer(('0.0.0.0', 56780), MyHandler)
        print 'started httpserver...'
        server.serve_forever()
    except KeyboardInterrupt:
        print '^C received, shutting down server'
        server.socket.close()

if __name__ == '__main__':
    main()
