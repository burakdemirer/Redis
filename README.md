# Redis
 A Simple Redis Web API

<pre><code>git clone https://github.com/burakdemirer/Redis.git</code></pre>

### Docker
<pre><code>docker pull redis</code></pre>
<pre><code>docker run --name myrediscache -p 5003:6379 -d redis</code></pre>
<pre><code>docker start myrediscache</code></pre>
<pre><code>docker exec -it myrediscache redis-cli</code></pre>

### API
<ul>
<li>Version .NET 5</li>
</ul>

1. Go to project directory 
<pre><code>cd Redis\Redis.Api.Demo\Redis.Api.Demo</code></pre>

2. Restore project dependency
<pre><code>dotnet restore</code></pre>

3. Run project
<pre><code>dotnet run</code></pre>

4. Open browser : <a href="https://localhost:5001/swagger" rel="nofollow">https://localhost:5001/swagger</a>
